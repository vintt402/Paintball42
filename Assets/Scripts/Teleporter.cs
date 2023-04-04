using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Teleporter : MonoBehaviour
{
    public GameObject destObj;

    public float x_offset;
    public float y_offset;

    private Vector2 dest;

    public void Start()
    {
        dest = new Vector2(destObj.transform.position.x + x_offset, destObj.transform.position.y + y_offset);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Bullet")
        {
            collision.transform.position = dest;
        }
    }
}
