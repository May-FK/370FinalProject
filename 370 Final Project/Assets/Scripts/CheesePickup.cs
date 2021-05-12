using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CheesePickup : MonoBehaviour
{
    private CheeseSpawner spawner;
    private bool playerCollided;
    private bool cheeseCollected;
    public AudioSource collected;
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
        if (playerCollided)
        {
            PickupCheese();
        }
        if ((collected.isPlaying == false) && cheeseCollected)
        {
            cheeseCollected = false;
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if ((!col.CompareTag("Player")) || (cheeseCollected)) return;
        playerCollided = true;
        collected.Play();
    }

    private void PickupCheese()
    {
        spawner.SpawnNewCheese();
        Score.increaseScore();
        cheeseCollected = true;
        playerCollided = false;
    }
}
