using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerPlayer2 : MonoBehaviour
{
    public int score;
    public static GameManagerPlayer2 inst;

    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] playerMovementPlayer2 playerMovement;

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
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
