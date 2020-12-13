using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagBehaviour : MonoBehaviour
{
    public bool checkpointFlag = true;
    public Sprite activeSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (checkpointFlag)
            {
                other.gameObject.GetComponent<AudioSource>().clip = other.gameObject.GetComponent<PlayerBehaviour>().flagSFX;
                other.gameObject.GetComponent<AudioSource>().Play();
                other.gameObject.GetComponent<PlayerBehaviour>().spawnPoint = this.gameObject.transform;
            }
            else
            {
                other.gameObject.GetComponent<PlayerBehaviour>().spawnPoint = GameObject.FindWithTag("StartingPosition").transform;
                SceneManager.LoadScene("Victory Screen");
            }
            gameObject.GetComponent<SpriteRenderer>().sprite = activeSprite;
        }
    }
}
