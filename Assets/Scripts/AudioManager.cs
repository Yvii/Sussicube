using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

//TODO: Credit Music

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.spatialBlend;
            s.source.outputAudioMixerGroup = s.audioMixerGroup;
        }

    }

    void Start()
    {

    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        //Prevent Null Refrence Exeption
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + " not found!");
            return;
        }
        Debug.Log("Attemting to Play Sound: " + s.name);
        s.source.Play();
    }

    public void PlayRandomCollisionSound()
    {
        Sound[] collisionSounds = Array.FindAll(sounds, sound => sound.name.Contains("Collision"));
        //Prevent Null Refrence Exeption
        if (collisionSounds == null)
        {
            Debug.LogWarning("Sound:" + name + " not found!");
            return;
        }

        System.Random rnd = new System.Random();
        Sound randomSound = collisionSounds[rnd.Next(0, collisionSounds.Length)];

        Debug.Log("Attemting to Play Sound: " + randomSound.name);
        randomSound.source.Play();
    }

    public void StopSound(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + " not found!");
            return;
        }
        Debug.Log("Attemting to Stop Sound: " + s.name);
        s.source.Stop();

    }

    public void PlayLevelTheme()
    {
        if (SceneManager.GetActiveScene().name.Contains("Level"))
        {
            string themeMusicName = SceneManager.GetActiveScene().name + "_Music";
            PlaySound(themeMusicName);
        }
    }

    public void ChangeToNextLevelTheme()
    {
        //get level index
        string helpu = SceneManager.GetActiveScene().name.Substring(5, 2);
        //gets us the level + 1 but we need a leading 0
        int levelindex = Convert.ToInt32(helpu) + 1;
        string levelIndexString = levelindex.ToString("D2");

        //if next Scene is a Level
        if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).name.Contains("Level"))
        {
            string themeMusicName = "Level" + levelIndexString + "_Music";
            //string themeMusicName = SceneManager.GetActiveScene().name + "_Music";
            PlaySound(themeMusicName);
        }
    }

    public void StopLevelTheme()
    {
        if (SceneManager.GetActiveScene().name.Contains("Level"))
        {
            string themeMusicName = SceneManager.GetActiveScene().name + "_Music";
            StopSound(themeMusicName);
        }
    }

    public void StopMenuTheme()
    {
        StopSound("MainMenu_Music");
    }

    public void StopEndScreenTheme()
    {
        StopSound("EndScreen_Music");
    }

    public void RestartLevelTheme(float delay)
    {
        StopLevelTheme();
        Invoke("PlayLevelTheme", delay);
    }

    public void RestartLevelTheme()
    {
        StopLevelTheme();
        Invoke("PlayLevelTheme", 0);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //New Scene is Loaded -> Here is where we do stuff
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Hallo hier in OnScreenLoaded AudioManager");
        if (SceneManager.GetActiveScene().name.Contains("Main Menu"))
        {
            StopEndScreenTheme();
            PlaySound("MainMenu_Music");
        }

        else if (SceneManager.GetActiveScene().name.Contains("Level"))
        {
            PlayLevelTheme();
        }

        else if (SceneManager.GetActiveScene().name.Contains("EndScreen"))
        {
            PlaySound("EndScreen_Music");
        }
    }
}
