using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpikes : MonoBehaviour
{
    public bool isActive;
    public BoxCollider2D hitBox;
    public Sprite activeSprite;
    public Sprite disabledSprite;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ToggleSpikes", 1.0f, 4.0f);
    }

    void Update()
    {
        
    }

    void ToggleSpikes()
    {
        if (isActive)
        {
            isActive = false;
            hitBox.enabled = true;
            spriteRenderer.sprite = activeSprite;
        }
        else
        {
            isActive = true;
            hitBox.enabled = false;
            spriteRenderer.sprite = disabledSprite;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Commit die.");
        }
    }
}
