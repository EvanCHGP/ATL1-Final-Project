using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    // Play Game
    public void PlayEasy()
    {
        SceneManager.LoadScene("Game (Easy)");
    }

    public void PlayMedium()
    {
        SceneManager.LoadScene("Game (Medium)");
    }

    public void PlayHard()
    {
        SceneManager.LoadScene("Game (Hard)");
    }

    public void PlayExtreme()
    {
        SceneManager.LoadScene("Game (Extreme)");
    }

    public void PlayMultiPlayer()
    {
        SceneManager.LoadScene("Game (Multiplayer)");
    }
    // Quit Game
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player Has Quit The Game!");
    }
}
