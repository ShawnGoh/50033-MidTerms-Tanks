using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float m_StartDelay = 3f;
    public float m_EndDelay = 3f;
    public float level;
    public CameraControl m_CameraControl;
    public Text m_MessageText;
    public GameObject[] m_TankPrefabs;
    public TankManager[] m_Tanks;
    public List<Transform> wayPointsForAI;

    public GameObject PauseScreen;
    public BooleanVariable BoolVar;
    public FloatVariable LevelScore;
    public FloatVariable CurrentScore;
    public GameConstants gameConstants;
    public GameObject EndScreen;
    public TMP_Text EndTitle;
    public FloatVariable LevelCleared;
    public AudioSource VictoryMusic;
    public GameObject NextLevelButton;
    public GameObject RetryButton;
    public GameObject TutorialScreen;
    public BooleanVariable TutorialCompleted;

    private WaitForSeconds m_StartWait;
    private WaitForSeconds m_EndWait;
    private float starsToWin;

    private void Awake()
    {
        if (TutorialCompleted.Value)
        {
            TutorialScreen.SetActive(false);
        }
        else
        {
            BoolVar.SetValue(true);
        }
    }

    private void Start()
    {
        m_StartWait = new WaitForSeconds(m_StartDelay);
        m_EndWait = new WaitForSeconds(m_EndDelay);
        CurrentScore.SetValue(0);
        SpawnAllTanks();
        SetCameraTargets();
        switch (level)
        {
            case 1:
                starsToWin = gameConstants.level1TotalStars;
                break;
            case 2:
                starsToWin = gameConstants.level2TotalStars;
                break;
            case 3:
                starsToWin = gameConstants.level3TotalStars;
                break;
        }

        StartCoroutine(GameLoop());
    }

    private void Update()
    {
        if (BoolVar.Value)
        {
            if (TutorialCompleted.Value)
            {
                PauseScreen.SetActive(true);
            }
            Time.timeScale = 0.0f;

        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }


    private void SpawnAllTanks()
    {
        m_Tanks[0].m_Instance =
            Instantiate(m_TankPrefabs[0], m_Tanks[0].m_SpawnPoint.position, m_Tanks[0].m_SpawnPoint.rotation) as GameObject;
        m_Tanks[0].m_PlayerNumber = 1;
        m_Tanks[0].SetupPlayerTank();

        for (int i = 1; i < m_Tanks.Length; i++)
        {
            Debug.Log(m_Tanks[i]);
            m_Tanks[i].m_Instance = Instantiate(m_TankPrefabs[i], m_Tanks[i].m_SpawnPoint.position, m_Tanks[i].m_SpawnPoint.rotation) as GameObject;
            m_Tanks[i].m_PlayerNumber = i + 1;
            m_Tanks[i].SetupAI(wayPointsForAI);
        }
    }


    private void SetCameraTargets()
    {
        Transform[] targets = new Transform[m_Tanks.Length];

        for (int i = 0; i < targets.Length; i++)
            targets[i] = m_Tanks[i].m_Instance.transform;

        m_CameraControl.m_Targets = targets;
    }


    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundStarting());
        yield return StartCoroutine(RoundPlaying());
        yield return StartCoroutine(RoundEnding());
    }


    private IEnumerator RoundStarting()
    {
        ResetAllTanks();
        DisableTankControl();

        m_CameraControl.SetStartPositionAndSize();

        m_MessageText.text = $"LEVEL {level}";

        yield return m_StartWait;
    }


    private IEnumerator RoundPlaying()
    {
        EnableTankControl();

        m_MessageText.text = string.Empty;

        while (PlayerStatus() && CurrentScore.Value != starsToWin) yield return null;
    }


    private IEnumerator RoundEnding()
    {
        DisableTankControl();
        m_MessageText.text = string.Empty;
        string message = "You Died!";
        if (PlayerStatus())
        {
            message = "Level " + level + " Cleared!";
            VictoryMusic.PlayOneShot(VictoryMusic.clip);
            if (LevelCleared.Value < 2)
            {
                LevelCleared.ApplyChange(1);
            }
        }
        else
        {
            NextLevelButton.SetActive(false);
            RetryButton.SetActive(true);
        }
        EndTitle.text = message;
        LevelScore.SetValue(CurrentScore.Value);

        EndScreen.SetActive(true);

        yield return m_EndWait;
    }


    private bool PlayerStatus()
    {
        return m_Tanks[0].m_Instance.activeSelf;
    }

    private void ResetAllTanks()
    {
        for (int i = 0; i < m_Tanks.Length; i++) m_Tanks[i].Reset();
    }


    private void EnableTankControl()
    {
        for (int i = 0; i < m_Tanks.Length; i++) m_Tanks[i].EnableControl();
    }


    private void DisableTankControl()
    {
        for (int i = 0; i < m_Tanks.Length; i++) m_Tanks[i].DisableControl();
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene($"Level{level}");
    }

    public void EndTutorial()
    {
        TutorialScreen.SetActive(false);
        TutorialCompleted.SetValue(true);
        BoolVar.SetValue(false);
    }
}