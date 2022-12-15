using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour
{
    private float rot = 0.0f;

    [SerializeField][Range(0.0f, 100.0f)] private float damp = 1.0f;

    private void FixedUpdate()
    {
        if ((int)GameObject.FindGameObjectsWithTag("ENEMY").Length == 2)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(new Vector3(80.0f, 0.0f, 0.0f)), Time.deltaTime);
        }
    }
}
