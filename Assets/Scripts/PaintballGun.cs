using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintballGun : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Spawn bullet
            Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        }
    }
}
