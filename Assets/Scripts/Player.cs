using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public float velocity = 6.5f;
    public float rotation_speed = 1f;

    public PaintballGun paintballGun;

    private int rotation_direction = 1;
    
    void Update()
    {
        // movement
        if (Input.GetKey("w"))
        {
            transform.position += transform.right * velocity * Time.deltaTime;
        } else
        {
            transform.Rotate(0, 0, rotation_direction * rotation_speed);
        }

        if (Input.GetKeyDown("w"))
        {
            rotation_direction = -rotation_direction;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            paintballGun.shoot();
            rotation_direction = -rotation_direction;
        }
    }
}
