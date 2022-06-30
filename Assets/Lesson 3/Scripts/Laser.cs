using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject explosion;
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.CompareTag("Asteroid"))
        {
            print("is asteroid");
            Destroy(collision.gameObject);
            Instantiate(explosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        }

    }
}