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
            movement.enabled = false;
            //AudioManager.instance.RestartLevelTheme();
            AudioManager.instance.StopLevelTheme();
            AudioManager.instance.PlayRandomCollisionSound();
            FindObjectOfType<GameManager>().EndGame();

        }

    }
}
