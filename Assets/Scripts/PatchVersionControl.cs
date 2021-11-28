using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatchVersionControl : MonoBehaviour
{
    //Change the Patch at https://analytics.cloud.unity3d.com/ when a new version comes out!!

    public string currentPatch = "0.3"; // Patch of the current Game
    public GameObject patchPanel;       //Shows a Waring that a new Patch is available

    // Start is called before the first frame update
    void Start()
    {
        string lastestPatch = RemoteSettings.GetString("currentPatch" , currentPatch); // Latest Version
        Debug.Log("Remote Server: Newest Patch: " + lastestPatch);

        if (currentPatch != lastestPatch && lastestPatch != null && lastestPatch != "")
        {
            patchPanel.SetActive(true);
        }
    }

    public string GetCurrentPatch()
    {
        return currentPatch;
    }

}
