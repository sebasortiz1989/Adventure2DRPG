﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolumeManager : MonoBehaviour
{
    private AudioVolumeController[] audios;
    [Range(0f, 1f)] public float maxVolumeLevel;
    [Range(0f, 1f)] public float currentVolumeLevel;

    // Start is called before the first frame update
    void Start()
    {
        audios = FindObjectsOfType<AudioVolumeController>();
        ChangeGlobalAudioVolume();
    }

    private void Update()
    {
        ChangeGlobalAudioVolume();
    }

    public void ChangeGlobalAudioVolume()
    {
        if (currentVolumeLevel >= maxVolumeLevel)
        {
            currentVolumeLevel = maxVolumeLevel;
        }

        foreach (AudioVolumeController avc in audios)
        {
            avc.SetAudioLevel(currentVolumeLevel);
        }
    }
}
