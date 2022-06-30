using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControl : MonoBehaviour
{

    private Rigidbody m_rigidbody;
    public float thrust;
    public float turningThrust;

    public Light thrustLight;

    public GameObject laserReference;

    public Transform laserSpawnPoint;

    public float laserForce;


    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MoveShip();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootLaser();
        }
        
    }

    void ShootLaser()
    {
        Debug.Log("pkew!");
        GameObject laserClone = Instantiate(laserReference, laserSpawnPoint.position, laserSpawnPoint.rotation);
        Rigidbody laserCloneRb = laserClone.GetComponent<Rigidbody>();
        laserCloneRb.AddRelativeForce(Vector3.forward * laserForce, ForceMode.Impulse);
    }

    void MoveShip()
    {
        thrustLight.enabled = false;

        if (Input.GetKey(KeyCode.W))
        {
            m_rigidbody.AddRelativeForce(Vector3.forward * thrust * Time.deltaTime);
            thrustLight.enabled = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_rigidbody.AddRelativeForce(Vector3.forward * -thrust * Time.deltaTime);
            thrustLight.enabled = true;
        }

        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            m_rigidbody.AddRelativeTorque(0f, mouseX * turningThrust * Time.deltaTime, 0f);
            m_rigidbody.AddRelativeTorque(mouseY * -turningThrust * Time.deltaTime, 0f, 0f);

            thrustLight.enabled = true;
        }
    }



}
