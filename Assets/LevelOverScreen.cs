using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LevelOverScreen : MonoBehaviour
{
    public GameConstants gameConstants;
    public FloatVariable LevelScore;
    public TMP_Text CurrentScore;
    public float currentLevel;
    public GameObject NextLevelButton;
    public AudioSource buttonClick;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0.0f;
    }

    void Start()
    {
        switch (currentLevel)
        {
            case 1:
                CurrentScore.text = "Current Score: " + LevelScore.Value + "/" + gameConstants.level1TotalStars;
                break;
            case 2:
                CurrentScore.text = "Current Score: " + LevelScore.Value + "/" + gameConstants.level2TotalStars;
                break;
            case 3:
                CurrentScore.text = "Current Score: " + LevelScore.Value + "/" + gameConstants.level3TotalStars;
                break;
        }
        if (currentLevel == 3)
        {
            NextLevelButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void NextLevel()
    {
        switch (currentLevel)
        {
            case 1:
                buttonClick.PlayOneShot(buttonClick.clip);
                SceneManager.LoadScene("Level2");
                break;
            case 2:
                buttonClick.PlayOneShot(buttonClick.clip);
                SceneManager.LoadScene("Level3");
                break;
        }

    }

    public void QuitToMainMenu()
    {
        buttonClick.PlayOneShot(buttonClick.clip);
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitToLevelSelect()
    {
        Debug.Log(LevelScore.Value);
        buttonClick.PlayOneShot(buttonClick.clip);
        SceneManager.LoadScene("LevelSelect");
    }
}
