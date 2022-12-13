using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkEnemyAI : MonoBehaviour
{
    public enum State                   // 적 캐릭터의 상태를 표현하기 위한 열거형 변수 정의
    {
        PATROL,
        TRACE,
        ATTACK,
        DIE
    }

    private GameObject player;

    private Transform playerTransform;  // 플레이어 캐릭터의 위치를 저장할 변수
    private Transform enemyTransform;   // 적 캐릭터의 위치를 저장할 변수
    private Animator animator;          // Animator Component를 저장할 변수

    private NavEnemyAI navEnemyAi;        // 이동을 제어하는 MoveAgnet class를 저장할 변수
    // private EnemyFire enemyFire;        // 총알 발사를 제어하는 EnemyFire class를 저장할 변수
    // private EnemyFOV enemyFOV;          // 시야각 및 추적 반경을 제어하는 EnemyFOV class를 저장할 변수
    private WaitForSeconds wfs;       // 코루틴에서 사용할 지연 변수

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("PLAYER");

        if (player != null)
        {
            playerTransform = GetComponent<Transform>();
        }

        enemyTransform = GetComponent<Transform>();    // 적 캐릭터의 Transform Component 추출
        animator       = GetComponent<Animator>();     // Animator Component 추출
        navEnemyAi = GetComponent<NavEnemyAI>();       // 이동을 제어하는 MoveAgnet class를 저장하는 변수
        // enemyFire      = GetComponent<EnemyFire>();    // 총알 발사를 제어하는 EnemyFire class 추출
        // enemyFOV       = GetComponent<EnemyFOV>();     // 시야각 및 추적 반경을 제어하는 EnemyFOV class를 추출

        wfs = new WaitForSeconds(0.3f);              // 코루틴의 지연 시간 생성

        // animator.SetFloat(hashOffset, Random.Range(0.0f, 1.0f));      // Cycle Offset 값을 불규칙하게 변경
        // animator.SetFloat(hashWalkSpeed, Random.Range(1.0f, 1.2f));   // Speed 값을 불규칙하게 변경

    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private IEnumerator CheckState()
    {
        yield return new WaitForSeconds(1.0f);


        while (true)
        {

        }
    }
}