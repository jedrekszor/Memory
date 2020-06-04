using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log(colorBlindMode);
        Debug.Log(parkinsonsMode);
        Debug.Log(muteMode);
    }

    private static bool colorBlindMode = false;
    private static bool parkinsonsMode = false;
    private static bool muteMode = false;

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