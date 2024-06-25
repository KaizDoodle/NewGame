using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Callbacks;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;

    public static bool canAttack = false;

    private Vector2 _movement;

    private Vector2 movementDirection;
    
    private Rigidbody2D _rb;
    private Animator _animator;

    // private Enemyattack enemy;

    // private EnemyMovement EnemyMovement;

    public bool ShouldBeDamaging {get; private set;} = false;
 

    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";
    private const string _lastHorizontal = "LastHorizontal";
    private const string _lastVertical = "LastVertical";


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        Enemyattack Enemyattack = new Enemyattack();
    }


    private void Update() {

        Debug.Log(Enemyattack.attackTimeCounter);
        

            
            if (EnemyMovement.target != null){
            
            if (Enemyattack.attackTimeCounter > 0.3){               
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, EnemyMovement.target.position, step);
                
                movementDirection = (EnemyMovement.target.position - transform.position).normalized;
            }else {
                movementDirection.Set( 0, 0);
            }
                _animator.SetFloat(_horizontal, movementDirection.x);
                _animator.SetFloat(_vertical, movementDirection.y);

                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>(); 
                
                if (movementDirection.x > 0)
                {
                    spriteRenderer.flipX = true;
                }
                else if (movementDirection.x < 0)
                {
                    spriteRenderer.flipX = false;
                }
            

                    if (movementDirection != Vector2.zero)
                    {
                        _animator.SetFloat(_lastHorizontal, movementDirection.x);
                        _animator.SetFloat(_lastVertical, movementDirection.y);
                    }
                    
                }
                else {

                    _animator.SetFloat(_horizontal, 0);
                    _animator.SetFloat(_vertical, 0);
                }
            }

        
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player"){
            canAttack = true;
            // target = other.transform;
            Debug.Log(target);
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            // target = null;
            canAttack = false;
        }
    }

}
