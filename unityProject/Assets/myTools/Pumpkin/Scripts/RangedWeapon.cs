using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public Transform firePoint; // Blaster, where projectile comes from
    public GameObject projectile;

    // Update is called once per frame
    void Update()
    {
        // key input will create instantiate a bullet
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(projectile, firePoint.position, firePoint.rotation);
    }

}
