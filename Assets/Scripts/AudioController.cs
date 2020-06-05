using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private static AudioSource source;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        source = gameObject.GetComponent<AudioSource>();
    }

    public static void playSound(AudioClip clip)
    {
        if (PlayerPrefs.GetInt("mute") == 0)
        {
            source.clip = clip;
            source.PlayOneShot(source.clip);
        }
    }

    public static void mute()
    {
        source.Stop();
    }
}
