using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverSinglePlayer : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = FindObjectOfType<GameManagerSinglePlayer>().score.ToString() + " Points";
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }   

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
