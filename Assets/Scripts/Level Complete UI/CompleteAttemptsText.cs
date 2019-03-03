using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteAttemptsText : MonoBehaviour
{
    // Start is called before the first frame update

    private Text txtAttempts;

    void Start()
    {
        txtAttempts = GetComponent<Text>();
        //Debug.Log(txtLevel.text);
        if (GameMonitor.instance.isCurrentLevelaPlayableLevel == true && txtAttempts != null)
        {
            //txtLevel
            txtAttempts.text = "ATTEMPTS: " + GameMonitor.instance.currentAttempts.ToString();
        }
    }
}
