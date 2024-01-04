using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


//when something get into the alta, make the runes glow


    public class PropsAltar : MonoBehaviour
    {
        public string LevelName;


        private void OnTriggerEnter2D(Collider2D other)
        {
            LoadLevel();
        }
        public void LoadLevel()
        {
            SceneManager.LoadScene(LevelName);
        }
        

    }

    
