using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToLevelNPC : MonoBehaviour
{

  private bool trigger;
  public string levelToLoad;

    
  void Update() {

    if(Input.GetKeyDown(KeyCode.E) && trigger) {
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
