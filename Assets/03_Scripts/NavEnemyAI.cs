using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Autohand.Demo;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavEnemyAI : MonoBehaviour
{
    public List<Transform> wayPoints;             // ���� �������� �����ϱ� ���� List Type ����

    [SerializeField][Range(0, 100)] private float           patrolSpeed = 0.0f;    // ��ȸ �ӵ�
 // [SerializeField][Range(0, 100)] private float           runSpeed    = 0.0f;    // �޸��� �ӵ�
 // [SerializeField][Range(0, 100)] private float           damping     = 1.0f;    // ������

    private Transform    enemyTransform;
    private Animator     animator;
    private NavMeshAgent aiAgent;
    public GameObject    pistol;

    private int          index;
    private int          deadCount;


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

        if (pistol.GetComponent<Pistol>().hitTarget)
        {
            deadCount++;

            if (deadCount >= 3)
            {
                aiAgent.isStopped = true;
                aiAgent.velocity = Vector3.zero;
                animator.SetTrigger("Die");
                Destroy(this);
                deadCount = 0;
            }
        }

    }
}
