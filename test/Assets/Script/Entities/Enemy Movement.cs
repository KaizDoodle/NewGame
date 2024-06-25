using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Callbacks;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public static Transform target;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player"){

            target = other.transform;
            Debug.Log(target);
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            target = null;
        }
    }

}
