using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheesePickup : MonoBehaviour
{
    private CheeseSpawner spawner;
    // Start is called before the first frame update
    void Awake()
    {
        if(spawner == null)
        {
            spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<CheeseSpawner>();
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (!col.CompareTag("Player")) return;
        spawner.SpawnNewCheese();
        this.gameObject.SetActive(false);
        
    }
}
