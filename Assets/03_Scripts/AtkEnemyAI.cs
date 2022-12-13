using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkEnemyAI : MonoBehaviour
{
    public enum State                   // �� ĳ������ ���¸� ǥ���ϱ� ���� ������ ���� ����
    {
        PATROL,
        TRACE,
        ATTACK,
        DIE
    }

    private GameObject player;

    private Transform playerTransform;  // �÷��̾� ĳ������ ��ġ�� ������ ����
    private Transform enemyTransform;   // �� ĳ������ ��ġ�� ������ ����
    private Animator animator;          // Animator Component�� ������ ����

    private NavEnemyAI navEnemyAi;        // �̵��� �����ϴ� MoveAgnet class�� ������ ����
    // private EnemyFire enemyFire;        // �Ѿ� �߻縦 �����ϴ� EnemyFire class�� ������ ����
    // private EnemyFOV enemyFOV;          // �þ߰� �� ���� �ݰ��� �����ϴ� EnemyFOV class�� ������ ����
    private WaitForSeconds wfs;       // �ڷ�ƾ���� ����� ���� ����

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("PLAYER");

        if (player != null)
        {
            playerTransform = GetComponent<Transform>();
        }

        enemyTransform = GetComponent<Transform>();    // �� ĳ������ Transform Component ����
        animator       = GetComponent<Animator>();     // Animator Component ����
        navEnemyAi = GetComponent<NavEnemyAI>();       // �̵��� �����ϴ� MoveAgnet class�� �����ϴ� ����
        // enemyFire      = GetComponent<EnemyFire>();    // �Ѿ� �߻縦 �����ϴ� EnemyFire class ����
        // enemyFOV       = GetComponent<EnemyFOV>();     // �þ߰� �� ���� �ݰ��� �����ϴ� EnemyFOV class�� ����

        wfs = new WaitForSeconds(0.3f);              // �ڷ�ƾ�� ���� �ð� ����

        // animator.SetFloat(hashOffset, Random.Range(0.0f, 1.0f));      // Cycle Offset ���� �ұ�Ģ�ϰ� ����
        // animator.SetFloat(hashWalkSpeed, Random.Range(1.0f, 1.2f));   // Speed ���� �ұ�Ģ�ϰ� ����

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