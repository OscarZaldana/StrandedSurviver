using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour {

    public AudioClip wind;
    public AudioClip spaceatm;
    public AudioClip sandWind;

    void Start()
    {
        AudioManager.audioInstance.PlayMusic(wind, 1f, 0);
        AudioManager.audioInstance.PlayMusic(spaceatm, 0.7f, 1);
        AudioManager.audioInstance.PlayMusic(sandWind, 0.7f, 2);
    }

    void Update()
    {

    }
}
