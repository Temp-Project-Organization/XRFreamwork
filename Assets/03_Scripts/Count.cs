using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour
{
    public GameObject gameManager;

    [SerializeField][Range(0.0f, 100.0f)] private float damp = 1.0f;

    private int enemyCount;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
    }

    private void Update()
    {
        enemyCount = (int)GameObject.FindGameObjectsWithTag("ENEMY").Length;
    }

    private void FixedUpdate()
    {
        if (enemyCount == 0)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(new Vector3(100.0f, 0.0f, 0.0f)), Time.deltaTime * damp);
        }
    }
}
