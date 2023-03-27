using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject projectilePrefab; // The prefab of the projectile to be fired
    public Transform firingPoint; // The point from which the projectile will be fired
    public float projectileSpeed = 10f; // The speed at which the projectile will be fired
    public float fireInterval = 1f; // The interval between firing the cannon in seconds
    public float projectileLifetime = 2f; // The lifetime of the projectile in seconds

    void Start()
    {
        InvokeRepeating("Fire", fireInterval, fireInterval); // Invoke the Fire method every fireInterval seconds
    }

    void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, firingPoint.position, Quaternion.identity); // Spawn the projectile at the firing point
        Rigidbody rb = projectile.GetComponent<Rigidbody>(); // Get the rigidbody component of the projectile
        rb.velocity = transform.right * projectileSpeed; // Set the velocity of the projectile to the right direction multiplied by the speed

        Destroy(projectile, projectileLifetime); // Destroy the projectile after the specified lifetime
    }
}
