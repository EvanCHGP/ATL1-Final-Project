using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathMessage : MonoBehaviour
{
    public GameObject deathScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(!FindObjectOfType<playerMovement>().alive && !(!FindObjectOfType<playerMovement>().alive && !FindObjectOfType<playerMovementPlayer2>().alive))
        {
            deathScreen.SetActive(true);
        }
        else {
            deathScreen.SetActive(false);
        }
    }
}
