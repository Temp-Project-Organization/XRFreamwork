using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Autohand.Demo;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TNavEnemyAI : MonoBehaviour
{
    public List<Transform> wayPoints;             // ���� �������� �����ϱ� ���� List Type ����

    [SerializeField][Range(0, 100)] private float           patrolSpeed = 0.0f;    // ��ȸ �ӵ�
 // [SerializeField][Range(0, 100)] private float           runSpeed    = 0.0f;    // �޸��� �ӵ�
 // [SerializeField][Range(0, 100)] private float           damping     = 1.0f;    // ������
    [SerializeField] private int deadState = 3;

    private Transform    enemyTransform;
    private Animator     animator;
    private NavMeshAgent aiAgent;
    public GameObject    pistol;
    private WaitForSeconds wfs;

    private int          index;
    private int          deadCount;
    private readonly int hashDieIndex = Animator.StringToHash("DieIndex");

    private void Awake()
    {
        enemyTransform  = GetComponent<Transform>();    // �� ĳ������ Tansform Component�� ���� ��, ������ ����
        animator        = GetComponent<Animator>();
        aiAgent         = GetComponent<NavMeshAgent>(); // NavMeshAgent Component�� ������ �� ������ ����

        aiAgent.autoBraking    = false;                 // �������� ����������� �ӵ��� �����ϴ� �ɼ� ��Ȱ��ȭ
        // aiAgent.updateRotation = false;              // �ڵ����� ȸ���ϴ� ��� ��Ȱ��ȭ

        deadCount = 0;
    }

    private void Start()
    {
        GameObject spawnGroup = GameObject.Find("Waypoint_Groups");
        wfs = new WaitForSeconds(0.3f);

        if (spawnGroup != null)
        {
            // wayPointGroup�� ������ �ִ� ��� Transform Component�� ������ ��,
            // List type�� wayPoints array�� �߰�
            spawnGroup.GetComponentsInChildren<Transform>(wayPoints);

            wayPoints.RemoveAt(0);
        }
    }

    private void Update()
    {
        aiAgent.speed = patrolSpeed;
        aiAgent.destination = wayPoints[index].position;  // ���� �������� wayPoints Array���� ������ ��ġ�� ���� �������� ����
        animator.SetBool("IsMove", true);

        if (aiAgent.velocity.sqrMagnitude >= 0.04f        // NavMeshAgent�� �̵��ϰ� �ְ�, ������ ���� ���� ���
            && aiAgent.remainingDistance <= 1.0f)
        {
            index = Random.Range(0, wayPoints.Count);
        }

        if (index > wayPoints.Count)
        {
            index = 0;
        }

        // ���⼭ hitTarget�� true�� �ȵǼ� ī������ �ȵǰ�, ���� ������� �ʴ� �� ����
        if (pistol.GetComponent<Pistol>().GetHitTarget())
        {
            deadCount++;
            Debug.Log(deadCount);
        }
    }

    private void OnEnable()
    {
        if (deadCount == deadState)
        {
            StartCoroutine(Action());
        }
    }

    private IEnumerator Action()
    {
        yield return wfs;

        if (deadCount == 3)
        {
            aiAgent.isStopped = true;
            aiAgent.velocity = Vector3.zero;
            animator.SetInteger(hashDieIndex, Random.Range(0, 3));
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}