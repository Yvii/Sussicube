using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardforce = 6000f;
    public float sideforce = 100f;
    public float jumpforce = 1000f;
    public float downforce = 0f;

    public bool noGravityMode = false;

    private bool isGrounded = false;
   

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("Ground") && isGrounded == false)
        {
            isGrounded = true;
            
        }
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
            if (noGravityMode == false && isGrounded == false)
            {
                return;
            }

            if (noGravityMode)
            {
                rb.AddForce(0, jumpforce * Time.deltaTime, 0, ForceMode.VelocityChange);
            }
            else
            {
                rb.AddForce(0, jumpforce * Time.deltaTime, 0, ForceMode.Impulse);
                isGrounded = false;
            }


        }

        //Down (only usable in noGravityMode)
        if ((Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow)) && downforce != 0 && noGravityMode == true)
        {
            Debug.Log("Down Test");
            rb.AddForce(0, -downforce * Time.deltaTime, 0, ForceMode.VelocityChange);

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
