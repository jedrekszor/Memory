﻿using System;
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
    private GameObject tickColorblind;
    private GameObject tickParkinsons;
    

    private Image muteButton;
    [SerializeField] private TextMeshProUGUI infoText;
    private TextMeshProUGUI muteText;

    private AudioController audio;
    private SoundtrackController soundtrack;

    private void Start()
    {
        audio = GameObject.Find("AudioManager").GetComponent<AudioController>();
        soundtrack = GameObject.Find("Soundtrack").GetComponent<SoundtrackController>();
        
        settings = GameObject.Find("SettingsMenu");
        muteButton = GameObject.Find("MuteButton").GetComponent<Image>();
        muteText = GameObject.Find("MuteText").GetComponent<TextMeshProUGUI>();
        tickColorblind = GameObject.Find("TickColorblind");
        tickParkinsons = GameObject.Find("TickParkinsons");

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
        tickColorblind.SetActive(PlayerPrefs.GetInt("colorBlindMode") == 1);
        tickParkinsons.SetActive(PlayerPrefs.GetInt("parkinsonsMode") == 1);
        
        
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
            tickColorblind.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("colorBlindMode", 0);
            tickColorblind.SetActive(false);
        }
    }

    public void changeParkinsonsMode()
    {
        if (PlayerPrefs.GetInt("parkinsonsMode") == 0)
        {
            PlayerPrefs.SetInt("parkinsonsMode", 1);
            tickParkinsons.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("parkinsonsMode", 0);
            tickParkinsons.SetActive(false);
        }
    }

    public void changeMuteMode()
    {
        if (PlayerPrefs.GetInt("mute") == 0)
        {
            PlayerPrefs.SetInt("mute", 1);
            muteText.text = "sound off";
            muteButton.sprite = muted;
            audio.mute();
            soundtrack.mute();
        }
        else
        {
            PlayerPrefs.SetInt("mute", 0);
            muteText.text = "sound on";
            muteButton.sprite = unmuted;
            soundtrack.startSoundtrack();
        }
    }

    public void colorblindInfo()
    {
        infoText.text = "Colors of the in-game buttons are easier to distinguish for colorblind people.";
    }

    public void parkinsonsInfo()
    {
        infoText.text = "Size of the in-game buttons is bigger making it easier for people with parkinson's disease to hit.";
    }
}