using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TMPro;
using UnityEngine;
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

    private bool blinkCd = true;
    private bool sequenceComplete = false;
    private bool awaitingInput = false;

    private bool canBlink = true;
    private bool canNoBlink = true;

    private Image bg;

    private TextMeshProUGUI tm;

    void Start()
    {
        foreach (Transform button in GameObject.Find("Buttons").transform)
        {
            buttons.Add(button.GetComponent<ButtonController>());
        }

        tm = GameObject.Find("Feedback").GetComponent<TextMeshProUGUI>();
        tm.enabled = false;
        bg = GameObject.Find("BG").GetComponent<Image>();
        bg.color = Color.gray;
        addToOrder();
        currentButton = order.ElementAt(0);
    }

    void Update()
    {
        if (!awaitingInput && buttonCount >= order.Count)
        {
            sequenceComplete = true;
            awaitingInput = true;
            buttonCount = 0;
            bg.color = Color.white;
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

    public void onClick(ButtonController b)
    {
        if (sequenceComplete && awaitingInput)
        {
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
                StartCoroutine(ojNieByczQ());
            }
        }
    }

    private IEnumerator ojTakByczq()
    {
        bg.color = Color.gray;
        yield return new WaitForSeconds(byczqTime);
        addToOrder();
        buttonCount = 0;
        sequenceComplete = false;
        awaitingInput = false;
    }

    private IEnumerator ojNieByczQ()
    {
        tm.enabled = true;
        bg.color = Color.gray;
        yield return new WaitForSeconds(byczqTime);
        tm.enabled = false;
        order.Clear();
        addToOrder();
        buttonCount = 0;
        sequenceComplete = false;
        awaitingInput = false;
    }
}