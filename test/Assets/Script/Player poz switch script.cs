// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// namespace Cainos.MainPlayerController
// {
//     public class PlayerPosition : MonoBehaviour
//     {
//         private PlayerController player;

//         void Start()
//         {
//             player = GetComponent<Transform>();
//             PlayerIsComingBack();
//         }

//         public void PlayerIsSwitchingScene()
//         {
//             PlayerPrefs.SetFloat("X", player.position.x);
//             PlayerPrefs.SetFloat("Y", player.position.y);
//             PlayerPrefs.SetFloat("Z", player.position.z);
//             // Player Switches Scene
//         }

//         public void PlayerIsComingBack()
//         {
//             // Player comes back
//             float x = PlayerPrefs.GetFloat("X");
//             float y = PlayerPrefs.GetFloat("Y");
//             float z = PlayerPrefs.GetFloat("Z");
//             player.position = new Vector3(x, y, z);
//         }
//     }
// }