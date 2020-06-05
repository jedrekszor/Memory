using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickSound : MonoBehaviour
{
    private Button button;
    private AudioClip click;

    void Start ()
    {
        click = Resources.Load<AudioClip>("click");
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){
        AudioController.playSound(click);
    }
}
