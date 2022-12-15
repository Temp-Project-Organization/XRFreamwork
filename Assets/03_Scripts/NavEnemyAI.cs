using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Autohand.Demo;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavEnemyAI : MonoBehaviour
{
    public List<Transform> wayPoints;                                              // ���� �������� �����ϱ� ���� List Type ����

    [SerializeField][Range(0, 100)] private float           patrolSpeed = 0.0f;    // ��ȸ �ӵ�
    [SerializeField] public int deadCounter = 0;

    private GameManager gameManager;                                                // GameManager�� ����� ��ũ��Ʈ ȣ��
    private Transform    enemyTransform;                                            // Enemy�� ���� Transform Component ȣ��
    private Animator     animator;                                                  // animator ȣ��
    private NavMeshAgent aiAgent;                               
    private Pistol pistol;

    private int          index;
    private int          counter = 0;

    private void Awake()
    {
        enemyTransform  = GetComponent<Transform>();    // �� ĳ������ Tansform Component�� ���� ��, ������ ����
        animator        = GetComponent<Animator>();
        aiAgent         = GetComponent<NavMeshAgent>(); // NavMeshAgent Component�� ������ �� ������ ����

        aiAgent.autoBraking    = false;                 // �������� ����������� �ӵ��� �����ϴ� �ɼ� ��Ȱ��ȭ
        // aiAgent.updateRotation = false;              // �ڵ����� ȸ���ϴ� ��� ��Ȱ��ȭ
    }

    private void Start()
    {
        pistol = GameObject.Find("pistol").GetComponent<Pistol>();

        GameObject wayPointGroups = GameObject.Find("Waypoint_Groups");

        if (wayPointGroups != null)
        {
            // wayPointGroup�� ������ �ִ� ��� Transform Component�� ������ ��,
            // List type�� wayPoints array�� �߰�
            wayPointGroups.GetComponentsInChildren<Transform>(wayPoints);

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
        else if (index > wayPoints.Count)
        {
            index = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("BULLET"))
        {
            counter++;
        }
        
        if(counter == deadCounter)
        {
            aiAgent.isStopped = true;
            aiAgent.velocity = Vector3.zero;
            animator.SetTrigger("Die");
            GetComponent<CapsuleCollider>().enabled = false;
            counter = 0;
        }
    }

    private void OnDisable()
    {
        gameManager.GetComponent<GameManager>().SetEnemyCount(1);
    }
}