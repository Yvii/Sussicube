using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveSphere : MonoBehaviour
{

    Material mat;
    private bool dissolveInProcess;

    public int dissolveChanceInPercent = 1;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    private void FixedUpdate()
    {
        if(dissolveInProcess)
        {
            Dissolve();
        }
        
    }

    public void Dissolve()
    {
        // mat.SetFloat("_DissolveAmount", Mathf.Sin(Time.time) / 2 + 0.5f);

        
        if (!dissolveInProcess)
        {
            int rnd = Random.Range(0, 100);
            Debug.Log(rnd);
            if (rnd < dissolveChanceInPercent)
            {
                dissolveInProcess = true;
            }
            
        }
        else
        {
            var dissolvestatus = mat.GetFloat("_DissolveAmount");

            if (dissolvestatus > 0.98f)
            {
                return;
            }
            else
            {
                mat.SetFloat("_DissolveAmount", dissolvestatus + 0.4f * Time.deltaTime);
            }
        }
        
        
    }
}