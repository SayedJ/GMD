using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int golds = 0;
    [SerializeField] private Text coinsText;
    [SerializeField]
    private GameObject wall;
    [SerializeField]
    private GameObject keypad;


   

    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.CompareTag("Gold"))
        {
            Destroy(other.gameObject);
            golds++;
            coinsText.text = "x " + golds;
            Destroy(wall, 1.0f);
            keypad.transform.Translate(Vector3.back * 20.0f * Time.deltaTime);
            

        }
        
    }
    
    

    void MoveDoor()
    {
        if (golds > 2)
        {
            Destroy(wall, 1.0f);
        }
    }
}
