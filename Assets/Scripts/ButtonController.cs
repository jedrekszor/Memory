using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public int id;
    public Color color;
    public Color color2;
    public AudioClip beep;
    
    private Image button;
    private bool colorblind;

    void Start()
    {
        button = transform.GetComponentInParent<Image>();
        colorblind = PlayerPrefs.GetInt("colorBlindMode") == 1;
    }

    public void setColor(bool set)
    {
        if (set)
        {
            if (colorblind)
                button.color = color2;
            else
                button.color = color;
        }
        else
        {
            button.color = Color.white;
        }
    }
}

