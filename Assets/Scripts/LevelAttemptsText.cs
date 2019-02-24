using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelAttemptsText : MonoBehaviour
{
    public TextMeshProUGUI txtLevel;

    // Start is called before the first frame update
    void Start()
    {
        txtLevel = GetComponent<TextMeshProUGUI>();
        //Debug.Log(txtLevel.text);
        if (GameMonitor.instance.isCurrentLevelaPlayableLevel == true && txtLevel != null)
        {
            //txtLevel
            txtLevel.text = "Level: " + GameMonitor.instance.currentLevel.ToString("D2") + "\n" + "Attempt: " + GameMonitor.instance.currentAttempts.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
