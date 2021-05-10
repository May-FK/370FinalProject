using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseSpawner : MonoBehaviour
{
    public GameObject[] pickups;
    private int randomCheese;

    private void Start()
    {
        SpawnNewCheese();
    }
    public void SpawnNewCheese()
    {
        randomCheese = (int)(Random.Range(0, pickups.Length) + .5f);
        pickups[randomCheese].SetActive(true);
    }
}
