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
        // do nothing if bullet collides with shooting player
        if (collision.tag == "Player")
        {
            return;
        }

        // destroy bullet
        Destroy(gameObject);

        // is object of collision an entity?
        if (collision.tag == "Entity")
        {
            // destroy entity
            Destroy(collision.gameObject);
        }
    }
}
