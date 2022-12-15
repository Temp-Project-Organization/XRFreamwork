using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField][Range(0.0f, 100.0f)] private float damp = 1.0f;

    private int counter;

    private void Awake()
    {
        counter = gameManager.GetComponent<GameManager>().GetMaxEnemy();
    }

    private void FixedUpdate()
    {
        if (counter == 0)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(new Vector3(100.0f, 0.0f, 0.0f)), Time.deltaTime * damp);
        }
    }
}
