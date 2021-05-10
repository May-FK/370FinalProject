using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseSpawner : MonoBehaviour
{
    public GameObject[] pickups;
    private int randomCheese = -1;
    private int oldRandomCheese = -1;

    public bool testRandom = false;
    private void Start()
    {
        SpawnNewCheese();
    }

    private void Update()
    {
        if (testRandom)
        {
            SpawnNewCheese();
            testRandom = false;
        }
    }
    public void SpawnNewCheese()
    {
        randIndex();
        pickups[randomCheese].SetActive(true);
    }

    private void randIndex()
    {
        do 
        { 
            randomCheese = (int)(Random.Range(0f, pickups.Length - 1) + .5f);
            Debug.Log(randomCheese);
        }
        while (randomCheese == oldRandomCheese);
        oldRandomCheese = randomCheese;
    }
}
