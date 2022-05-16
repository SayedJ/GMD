using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{

    private CharacterController _controller;
    private Vector3 playerVelocity;
    public float speed = 0.5f;
    public bool isGrounded = false;
    public bool crouching;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    private Animator anim;
    private bool isWalking = false;
    private static readonly int IsWalkingHash = Animator.StringToHash("IsWalking");
    [SerializeField] private AudioSource jumpSound;
    
   
    
    


    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
       
        
        
        isGrounded = _controller.isGrounded;
      
    }
// this method recieve the inputs for our InputManager.cs and apply them to our character controller.
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        _controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        _controller.Move(playerVelocity * Time.deltaTime);
        
       // Debug.Log(playerVelocity.y);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyHead"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    public void AnimationWalk(Vector2 desiredDirection)
    {
       
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = desiredDirection.x;
        moveDirection.z = desiredDirection.y;

        isWalking = (desiredDirection.x > 0.1f || desiredDirection.x < -0.1f ) ||
                   (desiredDirection.y > 0.1f || desiredDirection.y < -0.1f)
          ? true 
          : false;
        anim.SetBool(IsWalkingHash, isWalking);
        if (crouching)
        {
            anim.SetBool("IsCrouchWalking", isWalking);
        }
        
    }
    
    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
        
        anim.SetTrigger("IsJumping");
        jumpSound.Play();
    }

    public void Crouch()
    {
        crouching = !crouching;
       
        anim.SetBool("IsCrouching", crouching);
        anim.SetBool("IsStanding", crouching);  
        
    }

    public void Sprint()
    {
        
        speed = 4f;
        anim.SetFloat("Speed", 1);
   
    }
    
   
    
    
    
}
