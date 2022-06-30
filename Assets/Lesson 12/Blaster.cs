using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject laserPrefab;
    public float laserForce;

    public void Shoot()
    {
        GameObject laserClone = Instantiate(laserPrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody laserCloneRb = laserClone.GetComponent<Rigidbody>();
        laserCloneRb.AddRelativeForce(Vector3.forward * laserForce, ForceMode.Impulse);
    }
}
