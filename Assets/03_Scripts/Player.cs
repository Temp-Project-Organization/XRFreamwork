using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 0.0f;
    [HideInInspector] public float b = 0.0f;

    private Transform playerTransform;
    private Vector3 playerMove;

    private void Awake()
    {
        playerTransform = GetComponent<Transform>();
    }

    private void Start()
    {
            
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("W"))
        {

        }
        else if(Input.GetKey("A"))
        {
            
        }
        else if (Input.GetKey("S"))
        {

        }
        else if (Input.GetKey("D"))
        {

        }

        playerTransform.Translate(playerMove.normalized);
    }
}
