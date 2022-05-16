using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    
    
    [SerializeField] 
    private GameObject door;

    private bool doorOpen;

    private static readonly int IsOpen = Animator.StringToHash("isOpen");

  

    protected override void Interact()
    {
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool(IsOpen, doorOpen);
    }
    
}
