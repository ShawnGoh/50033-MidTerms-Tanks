using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    public GameConstants gameConstants;
    public FloatVariable Current;
    public FloatVariable LevelStar;
    public TMP_Text CurrentScore;
    public TMP_Text CurrentlvlText;
    public BooleanVariable BoolVar;
    public float CurrentLevel;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0.0f;
    }

    void Start()
    {
        CurrentlvlText.text = "Current Level: " + CurrentLevel;
        switch (CurrentLevel)
        {
            case 1:
                CurrentScore.text = "Current Score: " + Current.Value + "/" + gameConstants.level1TotalStars;
                break;
            case 2:
                CurrentScore.text = "Current Score: " + Current.Value + "/" + gameConstants.level2TotalStars;
                break;
            case 3:
                CurrentScore.text = "Current Score: " + Current.Value + "/" + gameConstants.level3TotalStars;
                break;
        }
        LevelStar.SetValue(Current.Value);
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }

    public void Resume()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        BoolVar.SetValue(false);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
