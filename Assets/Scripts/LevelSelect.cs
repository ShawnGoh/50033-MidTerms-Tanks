using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public GameConstants gameConstants;
    public FloatVariable LevelCleared;
    public FloatVariable Level1Star;
    public FloatVariable Level2Star;
    public FloatVariable Level3Star;
    public TMP_Text level1starcount;
    public TMP_Text level2starcount;
    public TMP_Text level3starcount;
    public GameObject level2Active;
    public GameObject level3Active;
    public GameObject level2Button;
    public GameObject level3Button;
    public AudioSource buttonClick;

    void Awake()
    {
        level1starcount.text = Level1Star.Value + " / " + gameConstants.level1TotalStars;
        level2starcount.text = Level2Star.Value + " / " + gameConstants.level2TotalStars;
        level3starcount.text = Level3Star.Value + " / " + gameConstants.level3TotalStars;
    }

    // Start is called before the first frame update
    void Start()
    {
        switch (LevelCleared.Value)
        {
            case 1:
                level2Active.SetActive(false);
                level2Button.GetComponent<Button>().interactable = true;
                break;
            case 2:
                level2Active.SetActive(false);
                level2Button.GetComponent<Button>().interactable = true;
                level3Active.SetActive(false);
                level3Button.GetComponent<Button>().interactable = true;
                break;
            default:
                level2Active.SetActive(true);
                level2Button.GetComponent<Button>().interactable = false;
                level3Active.SetActive(true);
                level3Button.GetComponent<Button>().interactable = false;
                break;
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Level1()
    {
        buttonClick.PlayOneShot(buttonClick.clip);
        SceneManager.LoadScene("Level1");
    }

    public void Level2()
    {
        buttonClick.PlayOneShot(buttonClick.clip);
        SceneManager.LoadScene("Level2");
    }

    public void Level3()
    {
        buttonClick.PlayOneShot(buttonClick.clip);
        SceneManager.LoadScene("Level3");
    }

    public void BackButton()
    {
        buttonClick.PlayOneShot(buttonClick.clip);
        SceneManager.LoadScene("MainMenu");
    }
}
