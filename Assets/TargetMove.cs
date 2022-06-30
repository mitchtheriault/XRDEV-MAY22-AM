using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    private float startPosition;

    public float moveSpeed;

    public float moveAmount;

    // Start is called before the first frame update
    void Awake()
    {
        startPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        var newPosition = transform.position;
        newPosition.x = startPosition + Mathf.Sin(Time.time * moveSpeed) * moveAmount;
        transform.position = newPosition;
    }
}
