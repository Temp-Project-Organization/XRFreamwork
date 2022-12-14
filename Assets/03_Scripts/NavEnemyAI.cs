using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Autohand.Demo;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavEnemyAI : MonoBehaviour
{
    public List<Transform> wayPoints;             // 순찰 지점들을 저장하기 위한 List Type 변수

    [SerializeField][Range(0, 100)] private float           patrolSpeed = 0.0f;    // 배회 속도
 // [SerializeField][Range(0, 100)] private float           runSpeed    = 0.0f;    // 달리기 속도
 // [SerializeField][Range(0, 100)] private float           damping     = 1.0f;    // 보정값

    private Transform    enemyTransform;
    private Animator     animator;
    private NavMeshAgent aiAgent;
    public GameObject    pistol;

    private int          index;
    private int          deadCount;


    private void Awake()
    {
        enemyTransform  = GetComponent<Transform>();    // 적 캐릭터의 Tansform Component를 추출 후, 변수에 저장
        animator        = GetComponent<Animator>();
        aiAgent         = GetComponent<NavMeshAgent>(); // NavMeshAgent Component를 추출한 후 변수에 저장

        aiAgent.autoBraking    = false;                 // 목적지에 가까워질수록 속도가 감소하는 옵션 비활성화
        // aiAgent.updateRotation = false;              // 자동으로 회전하는 기능 비활성화

        deadCount = 0;
    }

    private void Start()
    {
        GameObject spawnGroup = GameObject.Find("Waypoint_Groups");

        if (spawnGroup != null)
        {
            // wayPointGroup의 하위에 있는 모든 Transform Component를 추출한 뒤,
            // List type의 wayPoints array에 추가
            spawnGroup.GetComponentsInChildren<Transform>(wayPoints);

            wayPoints.RemoveAt(0);
        }
    }

    private void Update()
    {
        aiAgent.speed = patrolSpeed;
        aiAgent.destination = wayPoints[index].position;  // 다음 목적지를 wayPoints Array에서 추출한 위치로 다음 목적지를 지정
        animator.SetBool("IsMove", true);

        if (aiAgent.velocity.sqrMagnitude >= 0.04f        // NavMeshAgent가 이동하고 있고, 목적지 도착 여부 계산
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
