using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] points;

    [SerializeField] private GameObject enemy;
    [SerializeField] private List<GameObject> spawnPoint;
    [SerializeField] private int next = 0;
    [SerializeField] private int maxEnemy = 2;
    [SerializeField] private int enemyCount;

    private void Start()
    {
        points = GameObject.Find("SpawnPoint_Gruops").GetComponentsInChildren<Transform>();
        enemyCount = maxEnemy;

        if (points.Length > 0)
        {
            StartCoroutine(this.CreateEnemy());
        }
    }
    private IEnumerator CreateEnemy()
    {
        // 현재 생성된 적 캐릭터의 개수 산출
        int enemyCount = (int)GameObject.FindGameObjectsWithTag("ENEMY").Length;

        while (next < maxEnemy)
        {
            // 적 캐릭터의 최대 생성 개수보다 적을 때만 적 캐릭터를 생성
            if (enemyCount < maxEnemy)
            {
                // 적 캐릭터의 생성 주기 시간만큼 대기
                yield return new WaitForSeconds(0.1f);

                // 적 캐릭터의 동적 생성
                int index = Random.Range(0, points.Length);

                Instantiate(enemy, spawnPoint[next].transform.position, spawnPoint[next].transform.rotation);
                
                next++;
            }
            else
            {
                yield return null;
            }

        }
    }

    public int GetEnemyCount()
    {
        return enemyCount;
    }

    public void SetEnemyCount(int value)
    {
        enemyCount -= value;
    }
}
