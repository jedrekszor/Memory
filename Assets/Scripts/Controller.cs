﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public float blinkTime;
    public float noBlinkTime;
    public float byczqTime;

    private List<ButtonController> buttons = new List<ButtonController>();
    private List<int> order = new List<int>();
    private int currentButton;
    private int buttonCount = 0;
    private int score = 0;
    private int highScore = 0;

    private bool blinkCd = true;
    private bool sequenceComplete = false;
    private bool awaitingInput = false;

    private bool canBlink = true;
    private bool canNoBlink = true;

    private Image bg;
    private TextMeshProUGUI scoreTm;

    private GameObject feedback;
    private GameObject newHighScore;
    private TextMeshProUGUI scoreGameOver;
    private TextMeshProUGUI highScoreGameOver;
    
    private Color cantClick = new Color(157/255f, 171/255f, 189/255f, 1);
    private Color canClick = new Color(225/255f, 231/255f, 237/255f, 1);
    
    private AudioController audio;
    private SoundtrackController soundtrack;

    [SerializeField] private AudioClip newHighScoreClip;

    void Start()
    {
        audio = GameObject.Find("AudioManager").GetComponent<AudioController>();
        soundtrack = GameObject.Find("Soundtrack").GetComponent<SoundtrackController>();
        
        foreach (Transform button in GameObject.Find("Buttons").transform)
        {
            buttons.Add(button.GetComponent<ButtonController>());
            if (PlayerPrefs.GetInt("parkinsonsMode") == 1)
            {
                button.transform.localScale = new Vector3(1.5f, 1.5f, 1);
            }
        }
        newHighScore = GameObject.Find("NewHighScore");
        feedback = GameObject.Find("Feedback");
        scoreGameOver = GameObject.Find("GameOverScore").GetComponent<TextMeshProUGUI>();
        highScoreGameOver = GameObject.Find("GameOverHighScore").GetComponent<TextMeshProUGUI>();
        
        scoreTm = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        feedback.SetActive(false);
        bg = GameObject.Find("BG").GetComponent<Image>();
        addToOrder();
        currentButton = order.ElementAt(0);

        highScore = PlayerPrefs.GetInt("highScore");
        
        
        sequenceComplete = true;
        awaitingInput = true;
        buttonCount = 0;
        bg.color = canClick;

        StartCoroutine(startByczq());
    }

    void Update()
    {
        if (!awaitingInput && buttonCount >= order.Count)
        {
            sequenceComplete = true;
            awaitingInput = true;
            buttonCount = 0;
            bg.color = canClick;
        }

        if (!sequenceComplete)
        {
            currentButton = order.ElementAt(buttonCount);
            if (blinkCd)
            {
                if (canBlink)
                    StartCoroutine(blink());
            }
            else
            {
                if (canNoBlink)
                    StartCoroutine(noBlink());
            }
        }
    }

    private void addToOrder()
    {
        order.Add(Random.Range(0, buttons.Count));
    }

    private IEnumerator blink()
    {
        canBlink = false;
        audio.playSound(buttons.ElementAt(currentButton).beep);
        buttons.ElementAt(currentButton).setColor(true);
        yield return new WaitForSeconds(blinkTime);
        blinkCd = false;
        canBlink = true;
    }

    private IEnumerator noBlink()
    {
        canNoBlink = false;
        buttons.ElementAt(currentButton).setColor(false);
        buttonCount++;
        yield return new WaitForSeconds(noBlinkTime);
        blinkCd = true;
        canNoBlink = true;
    }

    private IEnumerator blinkOnce(ButtonController b)
    {
        b.setColor(true);
        yield return new WaitForSeconds(0.5f);
        b.setColor(false);
    }

    public void onClick(ButtonController b)
    {
        if (sequenceComplete && awaitingInput)
        {
            audio.playSound(b.beep);
            StartCoroutine(blinkOnce(b));
            if (b.id == order.ElementAt(buttonCount))
            {
                buttonCount++;
                if (buttonCount >= order.Count)
                {
                    StartCoroutine(ojTakByczq());
                }
            }
            else
            {
                ojNieByczQ();
            }
        }
    }


    private IEnumerator startByczq()
    {
        yield return new WaitForSeconds(byczqTime);
        bg.color = cantClick;
        buttonCount = 0;
        yield return new WaitForSeconds(0.5f);
        sequenceComplete = false;
        awaitingInput = false;
    }

    private IEnumerator ojTakByczq()
    {
        score++;
        scoreTm.text = score.ToString();
        yield return new WaitForSeconds(byczqTime);
        bg.color = cantClick;
        addToOrder();
        buttonCount = 0;
        yield return new WaitForSeconds(0.5f);
        sequenceComplete = false;
        awaitingInput = false;
    }

    private void ojNieByczQ()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
            newHighScore.SetActive(true);
            audio.playSound(newHighScoreClip);
        }
        else
        {
            newHighScore.SetActive(false);
        }

        scoreGameOver.text = score.ToString();
        highScoreGameOver.text = highScore.ToString(); 
        feedback.SetActive(true);
    }

    public void restart()
    {
        score = 0;
        scoreTm.text = score.ToString();
        bg.color = cantClick;
        order.Clear();
        addToOrder();
        buttonCount = 0;
        sequenceComplete = false;
        awaitingInput = false;
    }
    

    public void returnToMenu()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
        }
        SceneManager.LoadScene("Menu");
    }
}