using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorRandomizer : MonoBehaviour
{
    Color playerDefaultColor = new Color32(22, 85, 226, 255);

    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        Color super = renderer.material.color;
        //Debug.Log(super);
        Color randomColor = new Color(
          Random.Range(0f, 1f),
          Random.Range(0f, 1f),
          Random.Range(0f, 1f)
  );
        renderer.material.color = randomColor;
    }

}
