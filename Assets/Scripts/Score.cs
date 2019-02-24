using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{

    public Transform player;
    public Text scoretext;


    // Update is called once per frame
    void Update()
    {
        scoretext.text = player.position.z.ToString("0");
    }

    public void ChangeTextToRed()
    {
        scoretext.color = Color.red;
    }


}
