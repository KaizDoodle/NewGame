using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInteractionBase : MonoBehaviour, IInteractable
{
    public GameObject _player { get; set;}
    public bool CanInteract { get; set; }

    private Rigidbody2D _playerRigidbody;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerRigidbody = _player.GetComponent<Rigidbody2D>();
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

    private void FixedUpdate()
    {
        if (_playerRigidbody != null)
        {
            float distance = Vector2.Distance(_playerRigidbody.position, GetComponent<Rigidbody2D>().position);
            if (distance < 0.5f) // Adjust this value as needed
            {
                CanInteract = true;
            }
            else
            {
                CanInteract = false;
            }
        }
    }

    public virtual void Interact() {}

}
