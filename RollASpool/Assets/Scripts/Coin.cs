using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;
    public AudioClip coinSound;

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null) {
            Destroy(gameObject);
            return;
        }

        // Check that we collided with the player
        if (other.gameObject.name == "Player1") {

            // Add to the score
             GameManager.inst.IncrementScore();
        
            // Delete Coin
            Destroy(gameObject);

            // Play Pickup SFX
            AudioSource.PlayClipAtPoint(coinSound, transform.position, 1);
        }

        else if (other.gameObject.name == "Player2")
        {
            GameManagerPlayer2.inst.IncrementScore();

            Destroy(gameObject);

            AudioSource.PlayClipAtPoint(coinSound, transform.position, 1);
        }

        else if (other.gameObject.name == "Player")
        {
            GameManagerSinglePlayer.inst.IncrementScore();

            Destroy(gameObject);

            AudioSource.PlayClipAtPoint(coinSound, transform.position, 1);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
}
