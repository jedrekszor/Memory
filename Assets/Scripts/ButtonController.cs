using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public int id;
    public Color color;
    public AudioClip beep;
    
    private Image button; 
    
    void Start()
    {
        button = transform.GetComponentInParent<Image>();
    }

    public void setColor(bool set)
    {
        if (set)
        {
            button.color = color;
        }
        else
        {
            button.color = Color.white;
        }
    }
}

