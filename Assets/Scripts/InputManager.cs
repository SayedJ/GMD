using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    public PlayerInput.OnFootActions _onFoot;
    private float vertical;
    private float horizontal;
    private Rigidbody rb;
    
  

    private PlayerMotor _motor;
    private PlayerLook look;

    private Animator _animator;
    private static readonly int SpeedHash = Animator.StringToHash("Speed");


    private void Awake()
    {
        

        _animator = GetComponent<Animator>();
        
        _playerInput = new PlayerInput();
        _onFoot = _playerInput.OnFoot;
        
        _motor = GetComponent<PlayerMotor>();
        _onFoot.Jump.performed += ctx => _motor.Jump();
        look = GetComponent<PlayerLook>();
        _onFoot.Crouch.performed += ctx => _motor.Crouch();
        _onFoot.Sprint.performed += ctx => _motor.Sprint();
        
    }

   

    // Update is called once per frame
    private void FixedUpdate()
    { 
       _motor.ProcessMove(_onFoot.Movement.ReadValue<Vector2>());
       
       _motor.AnimationWalk(_onFoot.Movement.ReadValue<Vector2>());
       _animator.SetFloat(SpeedHash, vertical);
     
        
    }

    private void LateUpdate()
    {
        look.ProcessLook(_onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        _onFoot.Enable();
    }

    private void OnDisable()
    {
        _onFoot.Disable();
    }
}
