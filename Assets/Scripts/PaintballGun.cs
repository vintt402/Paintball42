using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintballGun : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    public int shootCount;
    public float shootInterval;

    public void Shoot()
    {
        StartCoroutine(SpawnBullets());
    }

    IEnumerator SpawnBullets()
    {
        for (int i = 0; i < shootCount; i++)
        {
            // spawn one bullet
            Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            yield return new WaitForSeconds(shootInterval);
        }
    }
}
