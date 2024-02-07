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
    public void Interact() {}

}
