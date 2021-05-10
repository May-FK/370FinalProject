using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheesePickup : MonoBehaviour
{
    private CheeseSpawner spawner;
    private bool playerCollided;
    // Start is called before the first frame update
    void Awake()
    {
        if(spawner == null)
        {
            spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<CheeseSpawner>();
        }
    }

    private void Update()
    {
        if (!playerCollided) return;
        PickupCheese();
    }
    private void OnTriggerEnter(Collider col)
    {
        if (!col.CompareTag("Player")) return;
        playerCollided = true;
    }

    private void PickupCheese()
    {
        spawner.SpawnNewCheese();
        Score.increaseScore();
        playerCollided = false;
        this.gameObject.SetActive(false);
    }
}
