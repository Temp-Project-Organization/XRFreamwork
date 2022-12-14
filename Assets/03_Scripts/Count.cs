using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour
{
    int count;
    private Animator animator;
    private void Awake()
    {
        count = (int)GameObject.FindGameObjectsWithTag("ENEMY").Length;
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        
    }


    private void Update()
    {

    }

    private void Counting()
    {
        if (count == 0)
        {
            animator.SetBool("isOpen", true);
        }
    }
}
