using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocity = 30f;

    public int team;

    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * velocity;
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
        } else if (collision.tag == "Player")
        {
            // ignore collisions with players of same team and dead players
            if (collision.gameObject.GetComponent<Player>().team != team && !collision.gameObject.GetComponent<Player>().dead)
            {
                collision.gameObject.GetComponent<Player>().die();
                Destroy(gameObject);
            }
        }
        else if (collision.tag == "Wall")
        {
            // destroy bullet
            Destroy(gameObject);
        }
    }
}
