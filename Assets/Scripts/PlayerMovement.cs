using System;
using UnityEngine;
//using UnityEngine.Experimental.Input;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardforce = 3000f;
    public float sideforce = 100f;
    public float jumpforce = 500f;
    public float downforce = 0f;

    public bool noGravityMode = false;

    [HideInInspector]
    public bool movementAllowed = true;

    private bool isGrounded = false;


    void OnCollisionEnter(Collision col)
    {
        //Reset Jumps
        if (col.gameObject.tag == ("Ground") && isGrounded == false)
        {
            isGrounded = true;

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Always add a forward force
        rb.AddForce(0, 0, forwardforce * Time.deltaTime);

        Vector2 moveaxis = FindObjectOfType<CubeInput>().getMoveaxis();
        if (moveaxis != new Vector2(0, 0))
        {
            Move(moveaxis);
        }

        if (rb.position.y < -5f)
        {
            //Play PlayerFalling Sound
            FindObjectOfType<GameManager>().EndGame("falling");
        }


    }

    public void Jump()
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

    public void Down()
    {
        //Only usable in no gravity mode
        if (downforce != 0 && noGravityMode == true)
        rb.AddForce(0, -downforce * Time.deltaTime, 0, ForceMode.VelocityChange);
    }

    public void Move(Vector2 movevector)
    {
        if(!movementAllowed)
        {
            return;
        }

        if (movevector.y > 0.1)
        {
            Jump();
        }

        if (movevector.y < -0.1)
        {
            Down();
        }

        if (movevector.x != 0)
        {
            rb.AddForce(sideforce * Time.deltaTime * movevector.x, 0, 0, ForceMode.VelocityChange);
        }

    }


}
