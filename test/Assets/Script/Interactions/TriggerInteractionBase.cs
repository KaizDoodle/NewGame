using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInteractionBase : MonoBehaviour, IInteractable
{
    public GameObject _player { get; set;}
    public bool CanInteract { get; set; }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        if (CanInteract)
        {
            if (InputManager.WasInteractPressed)
            {
                Interact();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _player)
        {
            CanInteract = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _player)
        {
            CanInteract = false;
        }
    }


    public virtual void Interact() {}

}
