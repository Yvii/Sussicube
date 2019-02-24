using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class GameAnalytics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // DontDestroyOnLoad(this.gameObject);
                
    }

    public void LevelComplete (string levelName)
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("Level", levelName);
        //data.Add("Score", score);

        Analytics.CustomEvent(levelName + " complete");
        Debug.Log("Sending Analytics Event");

    }

    public void LevelFailed (string levelName, Vector3 deathposition)
    {
       /*Dictionary<string, Vector3> data = new Dictionary<string, Vector3>();
        data.Add("Level", levelName);
        data.Add("Position", deathposition);*/

        Analytics.CustomEvent(levelName + " failed");
    }

    private void OnDestroy()
    {
        Analytics.FlushEvents();
       
    }
}
