using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePoint : MonoBehaviour
{

    void Start()
    {
        if(GameManager.instance.events["level00spawn"]) {
          transform.position = new Vector3 (4.5f, -0.5f, 0);
          GameManager.instance.events["level00spawn"] = false;
        } else if (GameManager.instance.events["level01spawn"]){
          transform.position = new Vector3 (2.5f, -0.5f, 0);
          GameManager.instance.events["level01spawn"] = false;
        } else {

        }
    }
}
