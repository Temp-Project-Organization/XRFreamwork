using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour
{
    public GameObject gameManager;

    [SerializeField][Range(0.0f, 100.0f)] private float damp = 1.0f;

    private void Awake()
    {
        // GameManager Prefabs
        gameManager = GameObject.Find("GameManager");
    }

    private void FixedUpdate()
    {
        if (gameManager.GetComponent<GameManager>().GetEnemyCount() == 2)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(new Vector3(100.0f, 0.0f, 0.0f)), Time.deltaTime * damp);
        }
    }
}
