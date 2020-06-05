using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource source;
    private static AudioController instance;

    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Object.Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
        source = gameObject.GetComponent<AudioSource>();
    }

    public void playSound(AudioClip clip)
    {
        if (PlayerPrefs.GetInt("mute") == 0)
        {
            source.clip = clip;
            source.PlayOneShot(source.clip);
        }
    }

    public void mute()
    {
        source.Stop();
    }
}
