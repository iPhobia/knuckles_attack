using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    public float fireRate;
    public Transform shotSpawn;

    [SerializeField]
    private GameObject bulletPrefab;
    private float nextFire;

    public void Shoot()
    {
        if (Time.time >= nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bulletPrefab, shotSpawn.position, shotSpawn.rotation);
        }
    }
}
