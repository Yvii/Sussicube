using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardforce = 1000f;
    public float sideforce = 500f;
    public float jumpforce = 1000f;
    [Range(0f, 1f)]
    public float gravityScale = 1f;

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
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && isGrounded && jumpforce != 0)
        {

            rb.AddForce(0, jumpforce * Time.deltaTime, 0, ForceMode.Impulse);
            isGrounded = false;

        }

        //Down
        /*if ((Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow)) && jumpforce != 0)
        {

            rb.AddForce(0, -jumpforce * Time.deltaTime, 0, ForceMode.Impulse);
            //canUseDown = false;

        }*/


        //Restart
        if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.Return))
        {
            //Avoid Restarting multiple Times per Buttonpress
            if (Score.GetCurrentScore() >= 10)
            {
                FindObjectOfType<GameManager>().Restart();
            }
            
        }

        //Main Menu
        /*if (Input.GetKey(KeyCode.Escape))
        {
            FindObjectOfType<GameManager>().EscapeToMainMenu();
        }*/



        if (rb.position.y < -5f)
        {
            //Play PlayerFalling Sound
            FindObjectOfType<GameManager>().EndGame("falling");


        }

    }
}
