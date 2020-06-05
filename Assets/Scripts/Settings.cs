using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    private static bool colorBlindMode;
    private static bool parkinsonsMode;
    private static bool muteMode;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        colorBlindMode = PlayerPrefs.GetInt("colorBlindMode") == 1;
        parkinsonsMode = PlayerPrefs.GetInt("parkinsonsMode") == 1;
        muteMode = PlayerPrefs.GetInt("mute") == 1;
    }


    public static bool ColorBlindMode
    {
        get => colorBlindMode;
        set => colorBlindMode = value;
    }

    public static bool ParkinsonsMode
    {
        get => parkinsonsMode;
        set => parkinsonsMode = value;
    }

    public static bool MuteMode
    {
        get => muteMode;
        set => muteMode = value;
    }
}