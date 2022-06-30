using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public List<GameObject> foods = new List<GameObject>();

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int randomIndex = Random.Range(0, foods.Count);
            Instantiate(foods[randomIndex], transform.position, transform.rotation);
        }
    }
}
