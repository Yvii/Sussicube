using UnityEngine;

public class PlayerMovementNoGravity : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardforce = 1000f;
    public float sideforce = 500f;
    public float jumpforce = 1000f;
    public float downforce = 1000f;
    
    
    void OnCollisionEnter(Collision col)
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //# TODO: Seperate Movement and Input
        //Always add a forward force
        rb.AddForce(0, 0, forwardforce * Time.deltaTime);

        //Right
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.AddForce(sideforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        //Left
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.AddForce(-sideforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        //Jump
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w")) && jumpforce != 0)
        {

            rb.AddForce(0, jumpforce * Time.deltaTime, 0, ForceMode.VelocityChange);

        }

        //Down
        if ((Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow)) && downforce != 0)
        {

            rb.AddForce(0, -downforce * Time.deltaTime, 0, ForceMode.VelocityChange);
            //canUseDown = false;

        }


        //Restart
        if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.Return))
        {
            //Avoid Restarting multiple Times per Buttonpress
            if (Score.GetCurrentScore() >= 10)
            {
                FindObjectOfType<GameManager>().Restart();
            }

        }

        //Load Secret Level
        if (Input.GetKey(KeyCode.F8))
        {
            FindObjectOfType<GameManager>().LoadTestLevel();
        }


        if (rb.position.y < -5f)
        {
            //Play PlayerFalling Sound
            FindObjectOfType<GameManager>().EndGame("falling");

        }

    }
}
