using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 20.0f;
    public float speed = 1000.0f;

    private float deleteTime;

    private Transform tr;
    private Rigidbody rb;
    private TrailRenderer trail;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        trail = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        deleteTime += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (deleteTime >= 2.0f)
        {
            this.gameObject.SetActive(false);

            // ��Ȱ��� �Ѿ��� ���� ȿ���� �ʱ�ȭ
            trail.Clear();
            tr.position = Vector3.zero;
            tr.rotation = Quaternion.identity;
            rb.Sleep();
        }
    }

    private void OnEnable()
    {
        rb.AddForce(transform.forward * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ENEMY"))
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("MAP"))
        {
            this.gameObject.SetActive(false);
        }
    }
}