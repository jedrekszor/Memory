using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private static bool colorBlindMode = true;
    private static bool parkinsonsMode = true;
    private static bool muteMode = true;

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