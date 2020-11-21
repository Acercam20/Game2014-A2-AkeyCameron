using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene("Platformer");
    }

    public void OnOptionsButtonPressed()
    {
        SceneManager.LoadScene("Options");
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }

    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
