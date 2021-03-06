﻿using UnityEngine.Audio;
using UnityEngine;

//Just a Basic Class for Sound
[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip audioClip;

    public AudioMixerGroup audioMixerGroup;

    [Range(0f,1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;
    [Range(0f, 1f)]
    public float spatialBlend;

    [HideInInspector]
    public AudioSource source;

    public bool loop;
}
