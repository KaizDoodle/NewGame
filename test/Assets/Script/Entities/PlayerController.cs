using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PlayerController : MonoBehaviour
    {
        private float _moveSpeed = 3f;
        
        private Vector2 _movement;
        
        private Rigidbody2D _rb;
        private Animator _animator;

        private const string _horizontal = "Horizontal";
        private const string _vertical = "Vertical";
        private const string _lastHorizontal = "LastHorizontal";
        private const string _lastVertical = "LastVertical";
        
        public int maxHealth = 5; 
        public int currentHealth;

        



        public Healthbar healthbar;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();

        }
        
        void Start() {
            currentHealth = maxHealth;
            healthbar.SetMaxHealth(3);
        }


        private void Update()
        {

            if (UserInput.WasShiftPressed) {
            _moveSpeed = 2.5f;
            } else {
                _moveSpeed = 1f;
            }


            _movement.Set(UserInput.Movement.x, UserInput.Movement.y);
            _rb.velocity = _movement * _moveSpeed;

            _animator.SetFloat(_horizontal, _movement.x);
            _animator.SetFloat(_vertical, _movement.y);

            // Get the SpriteRenderer component
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            // Flip the sprite on the x-axis if moving left
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
        }
        public void TakeDamage(int damage) {
            currentHealth -= damage;
            healthbar.SetHealth(currentHealth);
        }
    }

