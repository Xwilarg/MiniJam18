using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAudioManager : MonoBehaviour
{
    private bool playerTrigger;

    private void Update()
    {
        if(playerTrigger)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Destroy(AudioManager.instance);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            playerTrigger = true;

        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            playerTrigger = false;

        }
    }
}
