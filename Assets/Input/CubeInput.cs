using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;

public class CubeInput : MonoBehaviour
{
    public PlayerControls controls;
    private Vector2 moveaxis;



    private void OnEnable()
    {
        controls.Cube.Reset.performed += Reset_performed;
        controls.Cube.Reset.Enable();

        controls.Cube.Move.performed += Move_performed;
        controls.Cube.Move.Enable();

        controls.Cube.LoadSecretLevel.performed += LoadSecretLevel_performed;
        controls.Cube.LoadSecretLevel.Enable();
    }



    private void OnDisable()
    {
        controls.Cube.Reset.performed -= Reset_performed;
        controls.Cube.Reset.Disable();

        controls.Cube.Move.performed -= Move_performed;
        controls.Cube.Move.Disable();

        controls.Cube.LoadSecretLevel.performed -= LoadSecretLevel_performed;
        controls.Cube.LoadSecretLevel.Disable();
    }

    private void Reset_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Reset pressed");
        //Avoid Restarting multiple Times per Buttonpress (Could be obsolete with the new Input system)
        if (Score.GetCurrentScore() >= 5)
        {
            FindObjectOfType<GameManager>().Restart();
        }
    }

    private void Move_performed(InputAction.CallbackContext context)
    {
        moveaxis = context.ReadValue<Vector2>();
        Debug.Log("Moveaxis: " + moveaxis);
    }

    private void LoadSecretLevel_performed(InputAction.CallbackContext obj)
    {
        LoadSecretLevel();
    }

    public Vector2 getMoveaxis()
    {
        return moveaxis;
    }


    public void LoadSecretLevel()
    {
        FindObjectOfType<GameManager>().LoadTestLevel();
    }
}
