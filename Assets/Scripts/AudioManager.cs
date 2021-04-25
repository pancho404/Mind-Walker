using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager self;
    public AudioSource wakeUpSound;
    public AudioSource crashCarSound;
    public bool isWakeupSoundPlaying;
    public bool isCrashCarSoundPlaying;
    // Start is called before the first frame update
    void Start()
    {
        wakeUpSound.PlayDelayed(4f);
    }

    // Update is called once per frame
    void Update()
    {
        isWakeupSoundPlaying = wakeUpSound.isPlaying;
        isCrashCarSoundPlaying = crashCarSound.isPlaying;
    }

   
}
