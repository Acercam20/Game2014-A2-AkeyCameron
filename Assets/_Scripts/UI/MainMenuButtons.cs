using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
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
