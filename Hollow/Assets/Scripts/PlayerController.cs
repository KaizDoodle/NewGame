using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3.0F;
    public float groundDist;
    public LayerMask terrainLayer;

    private Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;
    public Animator animator;

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

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Determine the dominant direction of movement
        if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
        {
            moveDirection = new Vector3(horizontal, 0, 0);
        }
        else
        {
            moveDirection = new Vector3(0, 0, vertical);
        }

        moveDirection *= speed;

        controller.Move(moveDirection * Time.deltaTime);

        // Set the Horizontal and Vertical parameters based on the moveDirection vector
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.z);

    }
}
