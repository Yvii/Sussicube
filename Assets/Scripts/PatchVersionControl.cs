using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatchVersionControl : MonoBehaviour
{
    public string currentPatch = "0.3"; // Patch of the current Game
    public GameObject patchPanel;       //Shows a Waring that a new Patch is available

    // Start is called before the first frame update
    void Start()
    {
        string lastestPatch = RemoteSettings.GetString("currentPatch"); // Latest Version
        Debug.Log("Remote Server: Newest Patch: " + lastestPatch);

        if (currentPatch != lastestPatch)
        {
            patchPanel.SetActive(true);
        }
    }

    public string GetCurrentPatch()
    {
        return currentPatch;
    }

}
