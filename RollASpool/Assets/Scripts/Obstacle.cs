using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    playerMovement playerMovement;
    playerMovementPlayer2 playerMovementPlayer2;
    PlayerMovementSinglePlayer playerMovementSinglePlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<playerMovement>();  
        playerMovementPlayer2 = GameObject.FindObjectOfType<playerMovementPlayer2>();
        playerMovementSinglePlayer = GameObject.FindObjectOfType<PlayerMovementSinglePlayer>();
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        transform.rotation = new Quaternion(0, 180, 0, 0);
    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.name == "Player1") {

            // Kill the player
            playerMovement.Die();
        }
        else if(collision.gameObject.name == "Player2")
        {
            playerMovementPlayer2.Die();
        }

        else if(collision.gameObject.name == "Player")
        {
            playerMovementSinglePlayer.Die();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
