using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource buttonClick;

    public void PlayGame()
    {
        buttonClick.PlayOneShot(buttonClick.clip);
        SceneManager.LoadScene("LevelSelect");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
