using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackController : MonoBehaviour
{
    private static SoundtrackController instance;
    private AudioSource source;

    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        source = gameObject.GetComponent<AudioSource>();
        if(PlayerPrefs.GetInt("mute") == 0)
            startSoundtrack();
    }

    public void startSoundtrack()
    {
        if(PlayerPrefs.GetInt("mute") == 0)
            source.Play();
    }

    public void mute()
    {
        source.Stop();
    }
}
