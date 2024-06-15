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
    
    public int maxHealth = 5; 
    private int currentHealth;

    public Healthbar healthbar;




    // public GameObject[] _enemies { get; set;}
    // private List<BoxCollider2D> _enemyColliders;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    
    void Start() {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        //  _enemies = GameObject.FindGameObjectsWithTag("BadGuy");
        //  _enemyColliders = new List<BoxCollider2D>();

    }

    private void Update()
    {
        Debug.Log(currentHealth);

        
            if (UserInput.WasShiftPressed) {
                _moveSpeed = 2.5f;
            } else {
                _moveSpeed = 1f;
            }

            _movement.Set(UserInput.Movement.x, UserInput.Movement.y);
            _rb.velocity = _movement * _moveSpeed;

            _animator.SetFloat(_horizontal, _movement.x);
            _animator.SetFloat(_vertical, _movement.y);

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            if (_movement.x < 0)
            {
                spriteRenderer.flipX = true;
            } else if (_movement.x > 0)
            {
                spriteRenderer.flipX = false;
            }

            if (_movement != Vector2.zero){
                _animator.SetFloat(_lastHorizontal, _movement.x);
                _animator.SetFloat(_lastVertical, _movement.y);
            }
        

        if (currentHealth < 1){
             Death();
         }
    }

     public void TakeDamage(int damage) {
         currentHealth -= damage;
         healthbar.SetHealth(currentHealth);
     }

    // Add this method
     private void OnTriggerEnter2D(Collider2D other)
     {
         if (other.gameObject.CompareTag("BadGuy"))
         {
             TakeDamage(1);
         }
     }
     private void Death(){
         SceneManager.LoadScene("Title");
     }
}
