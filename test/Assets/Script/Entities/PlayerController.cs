using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float _moveSpeed = 3f;
    private Vector2 _movement;

    public static SceneSwapManager instance;
    private static PlayerAttack PlayerAttack;
    
    private Rigidbody2D _rb;
    private Animator _animator;

    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";
    private const string _lastHorizontal = "LastHorizontal";
    private const string _lastVertical = "LastVertical";

    private bool prevStatusVertical;
	private bool prevStatusHorizontal;
	private bool moveHorizontal;

    


    // public GameObject[] _enemies { get; set;}
    // private List<BoxCollider2D> _enemyColliders;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    
    void Start() {

        //  _enemies = GameObject.FindGameObjectsWithTag("BadGuy");
        //  _enemyColliders = new List<BoxCollider2D>();

    }

    private void Update()
    {
        if (UserInput.WasShiftPressed) {
            _moveSpeed = 2.5f;
        } else {
            _moveSpeed = 1f;
        }

        _movement.Set(UserInput.Movement.x, UserInput.Movement.y);
        
        _animator.SetFloat(_horizontal, _movement.x);
        _animator.SetFloat(_vertical, _movement.y);

         _rb.velocity = _movement * _moveSpeed;


        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        // Flip the sprite based on horizontal movement
        if (_movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (_movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        // Update the last movement direction if there was movement
        if (_movement != Vector2.zero)
        {
            _animator.SetFloat(_lastHorizontal, _movement.x);
            _animator.SetFloat(_lastVertical, _movement.y);
        }
    }
        
}

 
