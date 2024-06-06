using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistance : MonoBehaviour
{
    // Start is called before the first frame update

    public static Persistance instance;
    private void Awake()
    {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
