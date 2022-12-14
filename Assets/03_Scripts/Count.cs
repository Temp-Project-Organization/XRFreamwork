using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour
{
    int count;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Awake()
    {
        count = 0;
        animator = GetComponent<Animator>();
    }
    void Counting()
    {
        if (count == 2)
        {
            animator.SetBool("isOpen", true);
        }
    }
}
