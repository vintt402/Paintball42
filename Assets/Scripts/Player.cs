using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public float velocity;
    public float rotationVelocity;
    public bool mobileControl;

    public PaintballGun paintballGun;

    // only necessary for mobile control
    private int rotation_direction = 1;
    
    void Update()
    {
        // mobile control
        if (mobileControl)
        {
            if (Input.GetKey("w"))
            {
                // move
                transform.position += transform.right * velocity * Time.deltaTime;
            }
            else
            {
                // rotate if not moving
                transform.Rotate(0, 0, rotation_direction * rotationVelocity * Time.deltaTime);
            }

            if (Input.GetKeyDown("w"))
            {
                // change direction of rotation
                rotation_direction = -rotation_direction;

                // shoot
                paintballGun.Shoot();
            }
        }

        // desktop control
        else
        {
            // get user input
            float horizontalMovement = Input.GetAxisRaw("Horizontal");
            float verticalMovement = Input.GetAxisRaw("Vertical");

            Vector2 movementVector = new Vector2(horizontalMovement, verticalMovement);

            // move
            transform.Translate(movementVector * velocity * Time.deltaTime, Space.World);

            // rotate
            if (movementVector != Vector2.zero)
            {
                float angle = Mathf.Atan2(movementVector.y, movementVector.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }

            // shooting
            if (Input.GetButtonDown("Fire1"))
            {
                paintballGun.Shoot();
            }
        }
    }
}
