using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocity = 30f;
    public Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody.velocity = transform.right * velocity;
    }

    // Is triggered when bullet hits obstacle
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Entity")
        {
            // destroy bullet
            Destroy(gameObject);

            // destroy entity
            Destroy(collision.gameObject);
        } else if (collision.tag == "Wall")
        {
            // destroy bullet
            Destroy(gameObject);
        }
    }
}