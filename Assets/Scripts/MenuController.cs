using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI infoText;

    private void Start()
    {
        score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        score.text = PlayerPrefs.GetInt("highScore").ToString();
    }

    public void Play()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void changeColorBlindMode()
    {
        Settings.ColorBlindMode = !Settings.ColorBlindMode;
        if (Settings.ColorBlindMode)
        {
            PlayerPrefs.SetInt("colorBlindMode", 1);
        }
        else
        {
            PlayerPrefs.SetInt("colorBlindMode", 0);
        }
    }

    public void changeParkinsonsMode()
    {
        Settings.ParkinsonsMode = !Settings.ParkinsonsMode;
        if (Settings.ParkinsonsMode)
        {
            PlayerPrefs.SetInt("parkinsonsMode", 1);
        }
        else
        {
            PlayerPrefs.SetInt("parkinsonsMode", 0);
        }
    }

    public void changeMuteMode()
    {
        Settings.MuteMode = !Settings.MuteMode;
        if (Settings.MuteMode)
        {
            PlayerPrefs.SetInt("mute", 1);
        }
        else
        {
            PlayerPrefs.SetInt("mute", 0);
        }
    }

    public void colorblindInfo()
    {
        infoText.text = "Colorblind info";
    }

    public void parkinsonsInfo()
    {
        infoText.text = "Parkinsons info";
    }
}