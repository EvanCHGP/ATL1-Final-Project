using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathMessagePlayer2 : MonoBehaviour
{
    public GameObject deathScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!FindObjectOfType<playerMovementPlayer2>().alive && !(!FindObjectOfType<playerMovement>().alive && !FindObjectOfType<playerMovementPlayer2>().alive))
        {
            deathScreen.SetActive(true);
        }
        else {
            deathScreen.SetActive(false);
        }
        
    }
}
