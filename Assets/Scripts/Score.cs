using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{

    public Transform player;
    public Text scoretext;
    private static float score = 0;
    private float playerStartZPosition;

    void Start()
    {
        // Find Player start posotion
        playerStartZPosition = player.position.z;
    }


    // Update is called once per frame
    void Update()
    {
        //subtract current position from starting position to get the distance travelled 
        score = player.position.z - playerStartZPosition;
        scoretext.text = score.ToString("0");
    }

    public void ChangeTextToRed()
    {
        scoretext.color = Color.red;
    }

    public static float GetCurrentScore()
    {
        return score;
    }


}
