using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


//when something get into the alta, make the runes glow


    public class Door : MonoBehaviour
    {
        public string LevelName;
        public PlayerPosition playerPosition; // Reference to the PlayerPosition script

        private void OnTriggerEnter2D(Collider2D other)
        {
            LoadLevel();
            playerPosition.PlayerIsSwitchingScene(); // Save player position
        }
        public void LoadLevel()
        {
            
            SceneManager.LoadScene(LevelName);
            playerPosition.PlayerIsComingBack(); // Save player position
        }
        

    }