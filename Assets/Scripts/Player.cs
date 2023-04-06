using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public float velocity;
    public float rotationVelocity;

    public string controlKey;
    public int team;

    public PaintballGun paintballGun;

    // 0 => not pressed
    // 1 => pressed, first cycle
    // 2 => pressed, other cycle than first
    private int buttonPress = 0;

    private int rotation_direction = 1;

    private Vector3 startPos;

    private float respawnTime = 10;

    public bool dead = false;

    private void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        if (!dead)
        {
            if (Input.GetKey(controlKey) || buttonPress > 0)
            {
                // move
                transform.position += transform.right * velocity * Time.deltaTime;
            }
            else
            {
                // rotate if not moving
                transform.Rotate(0, 0, rotation_direction * rotationVelocity * Time.deltaTime);
            }

            if (Input.GetKeyDown(controlKey) || buttonPress == 1)
            {
                // change direction of rotation
                rotation_direction = -rotation_direction;

                // shoot
                paintballGun.Shoot();
            }

            if (buttonPress == 1)
            {
                // exit first cycle
                buttonPress++;
            }
        }
    }

    public void OnButtonDown()
    {
        if (buttonPress == 0)
        {
            buttonPress = 1;
        }
    }

    public void OnButtonUp()
    {
        buttonPress = 0;
    }

    public void die()
    {
        dead = true;
        StartCoroutine(respawn());
    }

    IEnumerator respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        transform.position = startPos;
        dead = false;
    }
}
