using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerSinglePlayer : MonoBehaviour
{
    public int score;
    public static GameManagerSinglePlayer inst;

    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] PlayerMovementSinglePlayer playerMovement;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
        // Increase the player's speed depending on score
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
