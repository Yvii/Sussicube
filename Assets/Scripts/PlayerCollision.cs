﻿using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement movement;
    public Score score;

    // Use this for initialization
    void OnCollisionEnter(Collision collisioninfo)
    {
        //Debug.Log("we hit " + collisioninfo.collider.name);

        //we ded
        if (collisioninfo.collider.tag == "Obstacle")
        {
            score.ChangeTextToRed();
            movement.movementAllowed = false;
            movement.enabled = false;
            try
            {
                GetComponentInChildren<DissolveSphere>().Dissolve();
            }
            catch
            {
                Debug.LogWarning("Player does not have a dissolve Shader!");
            }
            
            //AudioManager.instance.RestartLevelTheme();
            AudioManager.instance.StopLevelTheme();
            AudioManager.instance.PlayRandomCollisionSound();
            FindObjectOfType<GameManager>().EndGame();

        }

    }
}
