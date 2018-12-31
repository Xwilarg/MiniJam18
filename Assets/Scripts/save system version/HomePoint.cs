using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePoint : MonoBehaviour
{

    void Start()
    {
        if (GameManager.instance.events["level00spawn"])
        {
            transform.position = new Vector3(4.5f, -0.5f, 0);
            GameManager.instance.events["level00spawn"] = false;
        }
        else if (GameManager.instance.events["level01spawn"])
        {
            transform.position = new Vector3(2.5f, -0.5f, 0);
            GameManager.instance.events["level01spawn"] = false;
        }
        else if (GameManager.instance.events["level05spawn"])
        {
            transform.position = new Vector3(15.5f, 4.5f, 0);
            GameManager.instance.events["level05spawn"] = false;
        }
        else if (GameManager.instance.events["level04spawn"])
        {
            transform.position = new Vector3(31.5f, 10.5f, 0);
            GameManager.instance.events["level04spawn"] = false;
        }
        else if (GameManager.instance.events["level03spawn"])
        {
            transform.position = new Vector3(32.5f, 23.5f, 0);
            GameManager.instance.events["level03spawn"] = false;
        }
        else if (GameManager.instance.events["level02spawn"])
        {
            transform.position = new Vector3(10.5f, 24.5f, 0);
            GameManager.instance.events["level02spawn"] = false;
        }
    }
}
