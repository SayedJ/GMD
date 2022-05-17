using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name =="PlayerChar")
        {
            collision.gameObject.transform.SetParent(transform);
           
        }
 
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "PlayerChar")
        {
            other.gameObject.transform.SetParent(null);
        }
        
    }

    
}
