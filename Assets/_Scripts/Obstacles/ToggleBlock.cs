using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBlock : MonoBehaviour
{
    public Sprite toggledSpriteOn;
    public bool toggled;
    public BoxCollider2D hitBox;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        hitBox.enabled = false;
    }

    void Update()
    {
        
    }

    public void ToggleBlockOn()
    {
        toggled = true;
        spriteRenderer.sprite = toggledSpriteOn;
        hitBox.enabled = true;
    }
}
