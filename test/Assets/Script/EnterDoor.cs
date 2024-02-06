using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

namespace Level_one 
{
    public class EnterDoor : MonoBehaviour
    {
        public string sceneToLoad;
        private bool enterAllowed = false;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<WoodGate>())
            {
                sceneToLoad = "Inside";
                enterAllowed = true;
                PlayerIsSwitchingScene(); // Save player position
            }
            if (collision.GetComponent<WoodGateBack>())
            {
                sceneToLoad = "Level 1";
                enterAllowed = true;


            }
            else if (collision.GetComponent<PropsAlter>())
            {
                sceneToLoad = "Level2";
                enterAllowed = true;
                PlayerIsSwitchingScene(); // Save player position    
            }
            LoadLevel();
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.GetComponent<WoodGate>() || collision.GetComponent<PropsAlter>())
            {
                enterAllowed = false;
            }
        }
        public void LoadLevel()
        {
            SceneManager.LoadScene(sceneToLoad);
            PlayerIsComingBack(); // load player position
        }
        public void PlayerIsSwitchingScene()
        {
             PlayerPrefs.SetFloat("X", Player.position.x);
             PlayerPrefs.SetFloat("Y", Player.position.y);
             PlayerPrefs.SetFloat("Z", Player.position.z);
            // // saves player position 
        }
        public void PlayerIsComingBack()
        {
             float x = PlayerPrefs.GetFloat("X");
             float y = PlayerPrefs.GetFloat("Y");
             float z = PlayerPrefs.GetFloat("Z");
             Player.position = new Vector3(x, y, z);
            // // sets player position 
        }
    
    }
}