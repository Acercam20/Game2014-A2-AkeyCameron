using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBGMScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip Zephyr;
    public AudioClip StreetLove;
    private bool levelSwitch;
    private string levelName = "Main Menu";
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != levelName)
        {
            if (SceneManager.GetActiveScene().name == "Platformer")
            {
                GetComponent<AudioSource>().clip = Zephyr;
                GetComponent<AudioSource>().Play();
            }
            else if (GetComponent<AudioSource>().clip != StreetLove)
            {
                GetComponent<AudioSource>().clip = StreetLove;
                GetComponent<AudioSource>().Play();
            }
            levelName = SceneManager.GetActiveScene().name;
        }

    }
}
