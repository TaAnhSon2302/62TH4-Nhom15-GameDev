using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody2D myBody;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myBody.AddForce(new Vector2(1, 0) * bulletSpeed, ForceMode2D.Impulse);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
