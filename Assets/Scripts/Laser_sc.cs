using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_sc : MonoBehaviour
{
    public float speed = 10f;
        [SerializeField]

    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        rb.velocity = Vector3.up * speed;
    }

    void Update()
    {
        if (transform.position.y > 10f)
        {
            Destroy(gameObject);
        }
    }
}
