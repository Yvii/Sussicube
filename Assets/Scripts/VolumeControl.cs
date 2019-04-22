using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolumeMaster(float volume)
    {
        audioMixer.SetFloat("volumeMaster", volume);
    }

    public void SetVolumeMusic(float volume)
    {
        audioMixer.SetFloat("volumeMusic", volume);
    }

    public void SetVolumeSoundEffects(float volume)
    {
        audioMixer.SetFloat("volumeSoundEffects", volume);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
