using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3.0F;
    public float groundDist;
    public LayerMask terrainLayer;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;
        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if (hit.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDist;
                transform.position = movePos;
            }
        }

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection *= speed;

        // Log the moveDirection values
        Debug.Log("Move Direction: " + moveDirection);

        controller.Move(moveDirection * Time.deltaTime);

        if(moveDirection.x > 0)
        {
            animator.SetTrigger("MoveRight");
        }
        else if(moveDirection.x < 0)
        {
            animator.SetTrigger("MoveLeft");
        }
        else if(moveDirection.z > 0)
        {
            animator.SetTrigger("MoveForward");
        }
        else if(moveDirection.z < 0)
        {
            animator.SetTrigger("MoveBackward");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
    }
}
