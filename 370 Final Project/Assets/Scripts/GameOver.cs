using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public AudioSource select;
    public GameObject MainMenu;
    public GameObject AboutMenu;

    public void SelectSound()
    {
        select.Play();
    }
    public void Replay()
    {
        Score.resetScore();
        SceneManager.LoadScene("Garage");
    }

    public void About()
    {
        MainMenu.SetActive(false);
        AboutMenu.SetActive(true);
    }

    public void Main()
    {
        if(SceneManager.GetActiveScene().name == "Main Menu")
        {
            AboutMenu.SetActive(false);
            MainMenu.SetActive(true);
        }

        else
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
