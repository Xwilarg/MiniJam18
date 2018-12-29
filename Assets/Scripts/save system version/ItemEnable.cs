using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEnable : MonoBehaviour
{
    public string levelobject;
    private GameObject child;
    void Start()
    {
        child = this.gameObject.transform.GetChild(0).gameObject;
        if (GameManager.instance.events[levelobject]) {
            child.SetActive(true);
        }
    }
}
