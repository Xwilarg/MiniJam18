using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevelDoor : MonoBehaviour
{

  private bool trigger;
  public string levelspawn;
  public string levelToLoad = "World";

    
  void Update() {

    if(Input.GetKeyDown(KeyCode.E) && trigger) {
      GameManager.instance.events[levelspawn] = true;
      SceneManager.LoadScene(levelToLoad);
    } 
        
  }

  void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.name == "Player") {
      trigger = true;
    }
  }

  void OnTriggerExit2D(Collider2D other) {
    if (other.gameObject.name == "Player") {
      trigger = false;
    }
  }
}

