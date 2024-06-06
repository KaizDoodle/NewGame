using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInteractionBase : MonoBehaviour, IInteractable
{
    public GameObject _player { get; set;}
    public bool CanInteract { get; set; }
    private BoxCollider2D _doorCollider;
    private BoxCollider2D _playerCollider;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerCollider = _player.GetComponent<BoxCollider2D>();
        _doorCollider = GetComponent<BoxCollider2D>();
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == _player)
        {
            CanInteract = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == _player)
        {
            CanInteract = false;
        }
    }

    public virtual void Interact() {}

}
