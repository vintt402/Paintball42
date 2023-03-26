using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintballGun : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;

    public void shoot()
    {
        //Spawn bullet
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }
}
