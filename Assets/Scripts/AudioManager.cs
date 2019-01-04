using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private AudioSource audioS;
    public static AudioManager instance;
    

    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioS = GetComponent<AudioSource>();
        audioS.Play();
    }

    
    void Update()
    {
        
    }
}
