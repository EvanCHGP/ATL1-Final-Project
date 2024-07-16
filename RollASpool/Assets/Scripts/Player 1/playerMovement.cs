using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public GameOver gameOver;
    public bool alive = true;
    public float speed = 5;
    float rotationSpeed = 1;
    public float speedIncreasePerPoint = 0.3f;
    [SerializeField] Rigidbody rb;
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 
    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 1;
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    [SerializeField] Animator rollingAnimation;
    public float animationSpeedIncreasePerPoint = 1.2f;
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    public AudioClip deathSound;



    // Start Method, before the game is started
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // FixedUpdate Method, executed at a specified frame rate 
    private void FixedUpdate()
    {
        // Stops rolling animation if player is not alive
        if (!alive) 
        {
            rollingAnimation.enabled = false;
            rb.freezeRotation = false;
        }
        if (!alive) return;

        // Increases the rolling speed depending on the amount of points
        rollingAnimation.speed = (speed / 5) * animationSpeedIncreasePerPoint;

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~

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


    // Update Method, is called once per frame
    void Update()
    {
        // A & D/Left Arrow & Right Arrow movement call 
        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -0.7f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 0.7f;
        }
        else 
        {
            horizontalInput = 0;
        }




        // Kills player if y pos is less than -5
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

    // Die Method, what happens when the player runs into an obstacle
    public void Die()
    {

        if(alive) 
        {
            // Kill the Player
            alive = false;

            foreach(groundTile _groundTile1 in FindObjectsOfType<groundTile>())
            {
                _groundTile1.GetComponent<BoxCollider>().enabled = false;
               // Debug.Log(_groundSpawnerSingle.gameObject.name + " Has Been Disabled!");
            }

            // Add launch back force and rotational force on death
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 2, 0), ForceMode.Impulse);
            GetComponent<Rigidbody>().AddTorque(new Vector3(0, 180, 60), ForceMode.Impulse);
            

            // Tells the 'GameOver' screen to display the final score
            if(!FindObjectOfType<playerMovementPlayer2>().alive)
            {
                gameOver.Setup(FindObjectOfType<GameManager>().score);
            } 

            // Play death sound once on death
            if (!alive)
            {
            AudioSource.PlayClipAtPoint(deathSound, transform.position, 1);
            return;
            }
        }
    }

}
