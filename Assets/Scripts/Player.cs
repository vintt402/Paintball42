using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public float velocity;
    public float rotationVelocity;

    public PaintballGun paintballGun;

    // 0 => not pressed
    // 1 => pressed, first cycle
    // 2 => pressed, other cycle than first
    private int buttonPress = 0;

    private int rotation_direction = 1;
    
    void Update()
    {
        if (buttonPress > 0)
        {
            // move
            transform.position += transform.right * velocity * Time.deltaTime;
        }
        else
        {
            // rotate if not moving
            transform.Rotate(0, 0, rotation_direction * rotationVelocity * Time.deltaTime);
        }

        if (buttonPress == 1)
        {
            // change direction of rotation
            rotation_direction = -rotation_direction;

            // shoot
            paintballGun.Shoot();

            // exit first cycle
            buttonPress = 2;
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
}
