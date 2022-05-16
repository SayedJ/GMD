using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player_Colliding : MonoBehaviour
{
    
    [SerializeField] 
    private GameObject door;

    private ParticleSystem smoke;

    private bool doorOpen;
    
    [SerializeField] 
    private Text findTheKeyText;
  

    private static readonly int IsOpen = Animator.StringToHash("isOpen");

    private void Start()
    {
        
        findTheKeyText.enabled = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "GateOpener")
            doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool(IsOpen, doorOpen);

        if (collision.collider.name == "TextPopUp")
            findTheKeyText.enabled = true;
        
        if (collision.gameObject.CompareTag("EnemyHead"))
            Destroy(collision.transform.parent.gameObject);
        
        
    }

  

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.name == "TextPopUp")
            findTheKeyText.enabled = false;
        
    }
}
