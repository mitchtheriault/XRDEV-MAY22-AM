using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRespawn : MonoBehaviour
{
    public GameObject targetPrefab;
    public Collider spawnAreaCollider;


    private void OnCollisionEnter(Collision collision)
    {
        GameObject nextTarget = Instantiate(targetPrefab,GetRandomPosition(),Quaternion.identity);
        nextTarget.GetComponent<RandomRespawn>().spawnAreaCollider = spawnAreaCollider;
        Destroy(gameObject);
    }

    private Vector3 GetRandomPosition()
    {
        //calculate a random position in a range
        float xValue = Random.Range(spawnAreaCollider.bounds.min.x, spawnAreaCollider.bounds.max.x);
        float yValue = Random.Range(spawnAreaCollider.bounds.min.y, spawnAreaCollider.bounds.max.y);
        float zValue = Random.Range(spawnAreaCollider.bounds.min.z, spawnAreaCollider.bounds.max.z);

        return new Vector3(xValue, yValue, zValue);

    }

}
