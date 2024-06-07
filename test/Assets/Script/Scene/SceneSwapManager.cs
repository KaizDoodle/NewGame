using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapManager : MonoBehaviour
{

    public static SceneSwapManager instance;

    private static bool _loadFromDoor;

    private GameObject _player;
    private Collider2D _playerColl;
    private Collider2D _doorColl;

    private bool _doorType;
    private Vector3 _playerSpawnPosition;

    private DoorTriggerInteraction.DoorToSpawnAt _doorToSpawnTo;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _player = GameObject.FindGameObjectWithTag("Player");
        _playerColl = _player.GetComponent<Collider2D>();

    
    }

    private void OnEnable(){
        SceneManager.sceneLoaded += OnSceneLoded;
    }

    private void OnDisable(){
        SceneManager.sceneLoaded -= OnSceneLoded;
    }

    public static void SwapSceneFromDoorUse(SceneField myScene, DoorTriggerInteraction.DoorToSpawnAt doorToSpawnAt)
    {
        _loadFromDoor = true;
        instance.StartCoroutine(instance.FadeOutThenChangeScene(myScene, doorToSpawnAt));
    }

    private IEnumerator FadeOutThenChangeScene(SceneField myScene, DoorTriggerInteraction.DoorToSpawnAt doorToSpawnAt = DoorTriggerInteraction.DoorToSpawnAt.None)
    {
        SceneFadeManager.instance.StartFadeOut();

        while(SceneFadeManager.instance.IsFadingOut)
        {
            yield return null;
        }

        _doorToSpawnTo = doorToSpawnAt;
        SceneManager.LoadScene(myScene);
    }

    private void OnSceneLoded(Scene scene, LoadSceneMode mode){
        SceneFadeManager.instance.StartFadeIn();

        if(_loadFromDoor){
            FindDoor(_doorToSpawnTo);
            _player.transform.position = _playerSpawnPosition;
            _loadFromDoor = false;
        }
    }

    private void FindDoor(DoorTriggerInteraction.DoorToSpawnAt doorSpawnNumber){
        DoorTriggerInteraction[] doors = FindObjectsOfType<DoorTriggerInteraction>();

        for (int i = 0; i < doors.Length; i++){
            if(doors[i].CurrentDoorPosition == doorSpawnNumber){
                _doorColl = doors[i].gameObject.GetComponent<Collider2D>();

                if (SceneManager.GetActiveScene().name == "Room 2")
                CalculateSpawnPosition(true);
                else 
                CalculateSpawnPosition(false);
                return;
            }
        }
    }

    private void CalculateSpawnPosition(bool indoor){
        float colliderHeight = _playerColl.bounds.extents.y;
        
        if (indoor == true ){
            _playerSpawnPosition = _doorColl.transform.position - new Vector3(0f, colliderHeight - 2, 0f);
        } else {
            _playerSpawnPosition = _doorColl.transform.position - new Vector3(0f, colliderHeight, 0f);
        }
        

    }
}
