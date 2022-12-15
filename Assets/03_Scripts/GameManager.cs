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
        // ���� ������ �� ĳ������ ���� ����
        int enemyCount = (int)GameObject.FindGameObjectsWithTag("ENEMY").Length;

        while (next < maxEnemy)
        {
            // �� ĳ������ �ִ� ���� �������� ���� ���� �� ĳ���͸� ����
            if (enemyCount < maxEnemy)
            {
                // �� ĳ������ ���� �ֱ� �ð���ŭ ���
                yield return new WaitForSeconds(0.1f);

                // �� ĳ������ ���� ����
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
