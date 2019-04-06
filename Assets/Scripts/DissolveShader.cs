using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveShader : MonoBehaviour
{

    Material mat;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        var dissolvestatus = mat.GetFloat("_DissolveAmount");

        if (dissolvestatus > 0.98f)
        {
            return;
        }
        else
        {
            //mat.SetFloat("_DissolveAmount", dissolvestatus + 0.1f);
        }


    }
}