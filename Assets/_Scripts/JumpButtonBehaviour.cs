using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButtonBehaviour : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPressed()
    {
        player.GetComponent<PlayerBehaviour>()._Jump();
    }
}
