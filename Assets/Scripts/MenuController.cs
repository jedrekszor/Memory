using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    private TextMeshProUGUI score;
    private GameObject settings;
    public Sprite muted;
    public Sprite unmuted;

    private Image muteButton;
    [SerializeField] private TextMeshProUGUI infoText;
    private TextMeshProUGUI muteText;

    private void Start()
    {
        settings = GameObject.Find("SettingsMenu");
        muteButton = GameObject.Find("MuteButton").GetComponent<Image>();
        muteText = GameObject.Find("MuteText").GetComponent<TextMeshProUGUI>();

        score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        score.text = PlayerPrefs.GetInt("highScore").ToString();

        if (PlayerPrefs.GetInt("mute") == 1)
        {
            muteButton.sprite = muted;
            muteText.text = "sound off";
        }
        else
        {
            muteButton.sprite = unmuted;
            muteText.text = "sound on";
        }
        settings.SetActive(false);
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
        if (PlayerPrefs.GetInt("colorBlindMode") == 0)
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
        if (PlayerPrefs.GetInt("parkinsonsMode") == 0)
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
        if (PlayerPrefs.GetInt("mute") == 0)
        {
            PlayerPrefs.SetInt("mute", 1);
            muteText.text = "sound off";
            muteButton.sprite = muted;
        }
        else
        {
            PlayerPrefs.SetInt("mute", 0);
            muteText.text = "sound on";
            muteButton.sprite = unmuted;
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