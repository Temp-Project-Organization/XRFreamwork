using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour
{
    private float rot = 0.0f;

    private GameManager gameManager;

    [SerializeField][Range(0.0f, 100.0f)] private float damp = 1.0f;


    private void FixedUpdate()
    {
        if (gameManager.GetComponent<GameManager>().enemyCount == 0)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(new Vector3(100.0f, 0.0f, 0.0f)), Time.deltaTime);
        }
    }
}
