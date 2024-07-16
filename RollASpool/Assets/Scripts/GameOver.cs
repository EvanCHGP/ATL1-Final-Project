using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI pointsTextPlayer2;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = FindObjectOfType<GameManager>().score.ToString() + " Points";
        pointsTextPlayer2.text = FindObjectOfType<GameManagerPlayer2>().score.ToString() + " Points"; 
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
