using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//CURRENTLY ONLY USED FOR DEBUGGING

public class VersionText : MonoBehaviour
{

    public Text txtversion;
    public PatchVersionControl patchVersionControl;

    // Start is called before the first frame update
    void Start()
    {
        string lastestPatch = RemoteSettings.GetString("currentPatch"); // Latest Version
        txtversion = GetComponent<Text>();
        txtversion.text = lastestPatch + " " + patchVersionControl.GetCurrentPatch();

        if (lastestPatch == patchVersionControl.GetCurrentPatch())
        {
            txtversion.color = Color.green;
        }
        else
        {
            txtversion.color = Color.red;
        }
    }

}
