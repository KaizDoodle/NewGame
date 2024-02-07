using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour, IInteractable
{
    public GameObject Player { get; set;}
    public bool CanInteract { get; set; }

    private void Start() 
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
    }

    public void Update()
    {
        if (CanInteract)
        {
            if (UserInput.WasInteractPressed)
            {
                Interact();
            }
        }
    }

    private void OnTriggerEnter2d(Collider2D collision)
    {
        if (collision.GameObject == Player)
        {
            CanInteract = true;
        }

    }
    private void OnTriggerExit2d(Collider2D collision)
    {
        if (collision.GameObject == Player)
        {
            CanInteract = false;
        }
    }


    public virtual void Interact() {}

}
