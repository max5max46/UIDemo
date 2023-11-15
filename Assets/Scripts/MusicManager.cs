using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.Play();
    }

    public void PlayMusic()
    {
        musicSource.UnPause();
    }

    public void StopMusic()
    {
        musicSource.Pause();
    }
}
