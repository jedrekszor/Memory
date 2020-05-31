using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public int id;
    public Color color;
    private Image button; 
    
    void Start()
    {
        button = transform.GetComponentInParent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
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

