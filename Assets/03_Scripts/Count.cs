using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour
{
    int count;
    private Animator animator;
    private void Awake()
    {
        count = 0;
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
        if (count == 2)
        {
            animator.SetBool("isOpen", true);
        }
    }
}
