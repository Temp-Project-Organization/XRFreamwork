using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameManager gameManager;
    public static EnemyManager instance = null;

    [HideInInspector] public int count;

    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            if(instance != this)
            {
                Destroy(this);
            }
        }
    }

    public static EnemyManager Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }

            return instance;
        }
    }
}
