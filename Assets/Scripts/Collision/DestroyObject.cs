using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using Random = System.Random;

public class DestroyObject : MonoBehaviour
{
    [SerializeField]
    private GameObject floor;
    
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Shoes" || other.gameObject.CompareTag("Player"))
        {
            Destroy(floor, 1.5f);
            //transform.parent.Translate(Vector3.down * 6.0f * Time.deltaTime);
            //transform.Translate(Vector3.down * .1f * Time.deltaTime);
            //Destroy(gameObject);
            Debug.Log("GameOBject moved");
        }
    }

}
