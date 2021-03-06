﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
 
    public static GameManager instance;
    private GameObject homePoint;
    public IDictionary<string, bool> events = new Dictionary<string, bool>() {
        {"level00spawn", false},
        {"level01object", false },
        {"level01spawn", false},
        {"level02object", false },
        {"level02spawn:", false },
        {"level03object", false },
        {"level03spawn", false},
        {"level04object", false },
        {"level04spawn", false },
        {"level05object", false },
        {"level05spawn", false }

    };

    void Start()
    { 
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
        
    }
}
