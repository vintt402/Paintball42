using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintballGun : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    public int shootCount;
    public float shootInterval;

    private int team;

    public void Start()
    {
        team = gameObject.GetComponent<Player>().team;
    }

    public void Shoot()
    {
        StartCoroutine(SpawnBullets());
    }

    IEnumerator SpawnBullets()
    {
        for (int i = 0; i < shootCount; i++)
        {
            // spawn one bullet
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);

            // set team of bullet
            bullet.GetComponent<Bullet>().team = team;

            yield return new WaitForSeconds(shootInterval);
        }
    }
}
