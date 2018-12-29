using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSaver : MonoBehaviour
{
    private GameObject homePoint;

    void Start()
    {

      Scene currentScene = SceneManager.GetActiveScene();
      string sceneName = currentScene.name;

      if(sceneName == "World") {
        Debug.Log("Arriving to the World");
        homePoint = GameObject.FindGameObjectWithTag("HomePoint");
        Debug.Log(homePoint.transform.position);
        transform.position = homePoint.transform.position;
      }
      

    }

    
    void Update()
    {
        
    }
}
