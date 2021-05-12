using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer = 90f;
    public Text timerText;
    public GameObject GameOver;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DecrementTimer();
        timerText.text = "Time: " + ((float) System.Math.Round(timer, 2));
        if (timer > 0f) return;
        player.SetActive(false);
        timerText.gameObject.SetActive(false);
        GameOver.SetActive(true);
    }

    void DecrementTimer()
    {
        timer -= Time.deltaTime;
    }
}
