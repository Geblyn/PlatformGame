using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSensor : MonoBehaviour
{
    public bool playerDetected { get; private set;}
    public bool enemyDetected {get; private set;}

    public Transform Player {get; private set;}
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerDetected = true;
            Player = collision.gameObject.transform;
        }

        if(collision.gameObject.tag == "Enemy")
        {
            enemyDetected = true;
            playerDetected = false;
            Player = collision.gameObject.transform;
        }
        

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        playerDetected = false;
        enemyDetected = false;
        Player = null;
        
       
    }
}