 // using Cainos.PixelArtTopDown_Basic; ( put here whatever name space you are calling from )
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level_one 
{
public class Death : MonoBehaviour
{
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

      }

     private void OnTriggerEnter2D(Collider2D collision)
      {

         if (collision.GetComponent<BoxCollider2D>() != null)
         {
              player.GameOver();
          }

     }

  }
}