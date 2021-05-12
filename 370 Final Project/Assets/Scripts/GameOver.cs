using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene("Garage");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
