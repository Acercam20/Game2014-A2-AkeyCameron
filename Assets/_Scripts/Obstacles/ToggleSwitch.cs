using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSwitch : MonoBehaviour
{
    public Sprite toggledSwitch;
    public bool toggled = false;
    public GameObject blockToToggle;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            toggled = true;
            blockToToggle.GetComponent<ToggleBlock>().ToggleBlockOn();
            spriteRenderer.sprite = toggledSwitch;
        }
    }
}
