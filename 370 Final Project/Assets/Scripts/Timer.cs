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
    public AudioSource ten;
    public AudioSource three;
    public AudioSource gameOver;
    public bool isGameOver;
    private float lastSoundTime = -1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DecrementTimer();
        timerText.text = "Time: " + ((float) System.Math.Round(timer, 0));
        TimerSounds();
        if (timer > 0f) return;
        player.SetActive(false);
        timerText.gameObject.SetActive(false);
        GameOver.SetActive(true);
    }

    void TimerSounds()
    {
        if (isGameOver) return;
        if ((10.49f > timer) && (timer > 10.4f))
        {
            PlayTen();
        }
        else if ((9.49f > timer) && (timer > 9.4f))
        {
            PlayTen();
        }
        else if ((8.49f > timer) && (timer > 8.4f))
        {
            PlayTen();
        }
        else if ((7.49f > timer) && (timer > 7.4f))
        {
            PlayTen();
        }
        else if ((6.49f > timer) && (timer > 6.4f))
        {
            PlayTen();
        }
        else if ((5.49f > timer) && (timer > 5.4f))
        {
            PlayTen();
        }
        else if ((4.49f > timer) && (timer > 4.4f))
        {
            PlayTen();
        }
        else if ((3.49f > timer) && (timer > 3.4f))
        {
            PlayThree();
        }
        else if ((2.49f > timer) && (timer > 2.4f))
        {
            PlayThree();
        }
        else if ((1.49f > timer) && (timer > 1.4f))
        {
            PlayThree();
        }
        else if ((0.001f > timer) && (timer > -1.99f))
        {
            PlayGameOver();
            isGameOver = true;
        }
    }

    void DecrementTimer()
    {
        timer -= Time.deltaTime;
    }

    void PlayTen()
    {
        if (ten.isPlaying) return;
        Debug.Log(lastSoundTime - timer);
        if (((lastSoundTime - timer) < .5f) && !(lastSoundTime == -1f)) return;
        ten.PlayOneShot(ten.clip);
        lastSoundTime = timer;
    }

    void PlayThree()
    {
        if (three.isPlaying) return;
        if (((lastSoundTime - timer) < .5f) && !(lastSoundTime == -1f)) return;
        three.PlayOneShot(three.clip);
        lastSoundTime = timer;
    }

    void PlayGameOver()
    {
        if (three.isPlaying) return;
        if (((lastSoundTime - timer) < .5f) && !(lastSoundTime == -1f)) return;
        gameOver.PlayOneShot(gameOver.clip);
        lastSoundTime = timer;
    }
}
