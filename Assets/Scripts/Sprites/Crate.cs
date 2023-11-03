using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crate : MonoBehaviour
{
    public float moveSpeed = 2.0f;  // Adjust the speed as needed
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any update logic you need here
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Projectile"))
        {
            // Invert the crate's horizontal velocity
            rb.velocity = new Vector2(rb.velocity.x * -1, rb.velocity.y);
        }
    }
}
