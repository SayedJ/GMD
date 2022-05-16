using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLIfe : MonoBehaviour
{
     bool dead = false;
    private void Update()
    {
         if (transform.position.y < -4f && !dead)
        {
             Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
          
        }
        
    }

    private void Die()
    { 
       //GetComponent<Rigidbody>().isKinematic = true;
      //GetComponent<PlayerMotor>().enabled = false;
       //GetComponent<InputManager>().enabled = false;
       dead = true;
       Destroy(gameObject);
       ReloadLevel();
       
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
