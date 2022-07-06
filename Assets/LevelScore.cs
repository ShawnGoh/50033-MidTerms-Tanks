using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelScore : MonoBehaviour
{
    public GameConstants gameConstants;
    public FloatVariable ScoreVariable;
    public TMP_Text CurrentScore;
    private float current = 0;
    public float CurrentLevel;

    // Start is called before the first frame update
    void Awake()
    {
        ScoreVariable.SetValue(0);
    }

    void Start()
    {
        switch (CurrentLevel)
        {
            case 1:
                CurrentScore.text = "Current Score: " + ScoreVariable.Value + "/" + gameConstants.level1TotalStars;
                break;
            case 2:
                CurrentScore.text = "Current Score: " + ScoreVariable.Value + "/" + gameConstants.level2TotalStars;
                break;
            case 3:
                CurrentScore.text = "Current Score: " + ScoreVariable.Value + "/" + gameConstants.level3TotalStars;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreVariable.Value != current)
        {
            switch (CurrentLevel)
            {
                case 1:
                    CurrentScore.text = "Current Score: " + ScoreVariable.Value + "/" + gameConstants.level1TotalStars;
                    break;
                case 2:
                    CurrentScore.text = "Current Score: " + ScoreVariable.Value + "/" + gameConstants.level2TotalStars;
                    break;
                case 3:
                    CurrentScore.text = "Current Score: " + ScoreVariable.Value + "/" + gameConstants.level3TotalStars;
                    break;
            }
            current = ScoreVariable.Value;

        }

    }

    void FixedUpdate()
    {

    }
}
