using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    private void Update()
    {
        CheckPlayer();
    }


    public void CheckPlayer()
    {
        RaycastHit2D[] Hit = Physics2D.RaycastAll(transform.position, Vector3.down, 10f);

        if (Hit.Length > 0)
        {
            foreach (var item in Hit)
            {
                if (item.transform.GetComponent<Player>())
                {
                    rb.gravityScale = 1;
                }
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth player = collision.gameObject.GetComponent<Player>();

        if(player != null)
        {
            
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Ground"))
        {
            Move();
        }

        if(collision.gameObject.CompareTag("Limit"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        rb.velocity = Vector3.left * 5f;
    }
}
