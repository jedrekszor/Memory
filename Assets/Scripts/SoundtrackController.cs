using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackController : MonoBehaviour
{
    private static AudioSource source;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        source = gameObject.GetComponent<AudioSource>();
        if(PlayerPrefs.GetInt("mute") == 1)
            startSoundtrack();
    }

    public static void startSoundtrack()
    {
        if(PlayerPrefs.GetInt("mute") == 0)
            source.Play();
    }

    public static void mute()
    {
        source.Stop();
    }
}
