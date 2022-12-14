using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour
{
    int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Counting()
    {
        if (count == 3)
        {
            transform.GetComponent<Animator>().SetBool("door", true);
        }
    }
}
