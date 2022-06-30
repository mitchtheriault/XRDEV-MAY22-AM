using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabOffset : MonoBehaviour
{
    public Transform attachTransform;

    private void OnTriggerStay(Collider other)
    {
        attachTransform.position = other.transform.position;
        attachTransform.rotation = other.transform.rotation;
    }

}
