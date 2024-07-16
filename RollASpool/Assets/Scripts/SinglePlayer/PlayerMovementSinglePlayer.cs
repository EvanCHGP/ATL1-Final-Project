using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementSinglePlayer : MonoBehaviour
{
    public GameOverSinglePlayer gameOver;
    public AudioClip deathSound;
    public bool alive = true;
    public float speed = 5;
    public float rotationSpeed = 1;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 1;

    public float speedIncreasePerPoint = 0.2f;

    [SerializeField] Animator rollingAnimation;
    public float animationSpeedIncreasePerPoint = 1.2f;

    private void FixedUpdate()
    {
        if (!alive) return;

        // Makes the player move a constant speed while the game is running
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;

        // Uses the A/D input to make the player able to move left and right while constantly moving forward
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;

        // Sets the position of the Rigidbody to the forward and horizontal movement speed
        rb.MovePosition(rb.position + forwardMove + horizontalMove);


        Vector3 currentPosition = transform.position;
        Vector3 inputVector = new Vector3(horizontalInput * 5, 0, transform.position.z);
        inputVector += currentPosition;

        Quaternion targetRotation = Quaternion.LookRotation(inputVector - currentPosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed);
    }


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5) {
            Die();
        }
        // Kills player if left pos is less than -5
        if (transform.position.x < -5) {
            Die();
        }
        // Kills player if right pos is greater than 5
        if (transform.position.x > 5) {
            Die();
        }
    }

    // Die method
    public void Die()
    {
        if(alive) 
        {
            // Kill the Player
            alive = false;

            foreach(GroundTileSinglePlayer _groundTileSingle in FindObjectsOfType<GroundTileSinglePlayer>())
            {
                _groundTileSingle.GetComponent<BoxCollider>().enabled = false;
               // Debug.Log(_groundSpawnerSingle.gameObject.name + " Has Been Disabled!");
            } 

            rollingAnimation.enabled = false;
            // Add launch back force and rotational force on death
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 2, 0), ForceMode.Impulse);
            GetComponent<Rigidbody>().AddTorque(new Vector3(0, 180, 60), ForceMode.Impulse);
            

            // Tells the 'GameOver' screen to display the final score
            gameOver.Setup(FindObjectOfType<GameManagerSinglePlayer>().score);

            // Play death sound once on death
            if (!alive)
            {
            AudioSource.PlayClipAtPoint(deathSound, transform.position, 1);
            return;
            }
        }
    }

    void Restart()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}