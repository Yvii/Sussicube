using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [HideInInspector] // Hides var below
    public bool gameHasEnded = false;

    public float restartDelay = 1.5f;

    public GameObject levelCompleteUI;
    public GameAnalytics analytics;
    public TextMeshProUGUI txtLevel;
    public Animator playerAnimator;  //Used to play Running/death Animations

    void Start()
    {
        //Super Hacky
        //Todo: Variables for what Audio is currently playing
        if (GameMonitor.instance.isCurrentLevelaPlayableLevel == true)
        {
            AudioManager.instance.StopMenuTheme();
        }
        
        AudioManager.instance.RestartLevelTheme();
    }

    void OnDestroy()
    {
        AudioManager.instance.StopLevelTheme();
    }

    public void CompleteLevel()
    {
        //Debug.Log("WE WON!");
        levelCompleteUI.SetActive(true);
        analytics.LevelComplete(SceneManager.GetActiveScene().name);
    }

    public void EndGame(string reason = "")
    {
        if (gameHasEnded == false)
        {
            //Debug.Log("Game Over");
            DisableObstacleMovement();
            gameHasEnded = true;
            playerAnimator.SetBool("isDead", true);
            //TODO: Deathvector
            analytics.LevelFailed(SceneManager.GetActiveScene().name, new Vector3(0, 0, 0));
            AudioManager.instance.StopLevelTheme();
            if (reason == "falling")
            {
                AudioManager.instance.PlaySound("PlayerFallingDeath");
            }
            //Restart
            Invoke("Restart", restartDelay);

        }

    }

    private void DisableObstacleMovement()
    {
        var obstacles = FindObjectsOfType<ObstacleMovement>();
        foreach (var element in obstacles)
        {
            element.DisableMovement();
        }
    }

    public void Restart()
    {
        //Load Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Start Audio Level Theme
        AudioManager.instance.PlayLevelTheme();

    }

    public void LoadTestLevel()
    {
        //Load Scene
        Debug.Log("Trying to load level 08");
        SceneManager.LoadScene("Level08");
    }

    public void EscapeToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }


}
