using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour {

    public AudioClip wind;

    void Start()
    {
        AudioManager.audioInstance.PlayMusic(wind, 0.7f, 1);
    }

    void Update()
    {

    }
}
