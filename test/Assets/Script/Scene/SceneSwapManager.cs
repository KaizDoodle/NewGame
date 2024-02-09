using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapManager : MonoBehaviour
{

    public static SceneSwapManager instance;

    private DoorTriggerInteraction.DoorToSpawnAt _doorToSpawnTo;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public static void SwapSceneFromDoorUse(SceneField myScene, DoorTriggerInteraction.DoorToSpawnAt doorToSpawnAt)
    {
        instance.StartCoroutine(instance.FadeOutThenChangeScene(myScene, doorToSpawnAt));
    }

    private IEnumerator FadeOutThenChangeScene(SceneField myScene, DoorTriggerInteraction.DoorToSpawnAt doorToSpawnAt = DoorTriggerInteraction.DoorToSpawnAt.None)
    {
        //start fading to black 
        yield return null;
        //keep fading out 
        _doorToSpawnTo = doorToSpawnAt;
        SceneManager.LoadScene(myScene);
    }
}
