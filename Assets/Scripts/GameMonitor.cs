using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Singleton keeping Track of the GameStats such as Levels, Fails etc.
public class GameMonitor : MonoBehaviour
{
        
    public static GameMonitor instance;
    public delegate void OnLevelChangedHandler();

    public event OnLevelChangedHandler OnLevelChanged;

    public int currentLevel;
    public int currentAttempts = 1;
    public int[] attempts;
    public bool isCurrentLevelaPlayableLevel = false;
    public string[] sceneType;

    private float AttemptRestartDelay = 0.5f;  //Can only increment Attempts every 2 secs
    private float lastRestart;

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

        //Set Time to now
        lastRestart = Time.time;
        DontDestroyOnLoad(gameObject);

        //Levelindex
        int scenecount = SceneManager.sceneCountInBuildSettings;
        string[] scenes = new string[scenecount];  // Level, Main Menu, Credits
        string[] _sceneType = new string[scenecount];  // Level, Main Menu, Credits
        //Looping thorugh all Scenes
        for (int i = 0; i<scenecount; i++)
        {
            //scenes[i] = SceneManager.GetSceneByBuildIndex(i);
            //Getting Scene Names
            scenes[i] = System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i));

            if (scenes[i].ToString().Contains("Level"))
            {
                _sceneType[i] = "Level";
            }
            if (scenes[i].ToString().Contains("Main Menu"))
            {
                _sceneType[i] = "Main Menu";
            }
            if (scenes[i].ToString().Contains("EndScreen"))
            {
                _sceneType[i] = "End Screen";
            }


        }

        sceneType = _sceneType;
        /*Debug.Log("SceneTypes:");
        foreach (string s in sceneType)
        {
            Debug.Log("Scene: " + s);
        }*/
  
    }

        // Start is called before the first frame update
    void Start()
    {
        //Attention: Only works as long as Level 1 is at index 1 
        currentLevel = SceneManager.GetActiveScene().buildIndex;
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
        //Check if a new Level is Loaded
        if (currentLevel != SceneManager.GetActiveScene().buildIndex)
        {
            //If Level has Changed fire an Event
            Debug.Log("OnLevelChanged Event fired!");
            currentAttempts = 1;
            if (OnLevelChanged != null)
            {
                OnLevelChanged();
            }
            
            //instance.OnLevelChanged();
        }
        //If Level is still the same but restarted
        else
        {
            //if the last Attemptsincrease was at least [Restart Delay] in the past
            if (lastRestart + AttemptRestartDelay < Time.time)
            {
                currentAttempts++;
                lastRestart = Time.time;
            }
            
        }
        currentLevel = SceneManager.GetActiveScene().buildIndex;

        //Check if Level is a Level or something else like a Menu
        if (sceneType[currentLevel] == "Level")
        {
            isCurrentLevelaPlayableLevel = true;
        }
        else
        {
            isCurrentLevelaPlayableLevel = false;
        }
        //Debug.Log("Scene Loaded");
    }
}
