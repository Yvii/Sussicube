using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeOut : MonoBehaviour
{
    //Fade time in seconds
    public float period = 5.0f;
    void Update()
    {
        //Destroy Gameobject so it doesnt Show up anymore, even if we restart
        if (Time.time > period)
        {
            Destroy(gameObject);
        }

        Color colorOfObject = GetComponent<Text>().color;
        float prop = (Time.time / period);
        colorOfObject.a = Mathf.Lerp(1, 0, prop);
        GetComponent<Text>().color = colorOfObject;
    }
}

