using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteLevelText : MonoBehaviour
{

    private Text txtLevel;

    void Start()
    {
        txtLevel = GetComponent<Text>();
        //Debug.Log(txtLevel.text);
        if (GameMonitor.instance.isCurrentLevelaPlayableLevel == true && txtLevel != null)
        {
            //txtLevel
            txtLevel.text = "LEVEL: " + GameMonitor.instance.currentLevel.ToString("D2");
        }
    }
}
