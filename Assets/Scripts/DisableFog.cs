using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableFog : MonoBehaviour
{
    // Disable Fog in a Level
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Disabling Fog");
        RenderSettings.fog = false;
    }

}
