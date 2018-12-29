using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSprite : MonoBehaviour
{
    public Sprite unpressed;
    public Sprite pressed;
    private SpriteRenderer sp;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        
    }
}
