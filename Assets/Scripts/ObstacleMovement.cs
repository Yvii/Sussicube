using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public bool isMoving = false;
    public float sideforce = 0f;
    public float forwardforce = 0f;
    public float secsToInvertMoveAxis = 1f;
    public float speed = 1f;                    //Speed in units per sec

    //private float startTime;
    private float currentTime;
    private Vector3 startposition;
    private Vector3 endposition;
    private Vector3 targetposition;


    public void DisableMovement()
    {
        isMoving = false;
    }

    void Start()
    {
        //startTime = Time.time;
        currentTime = Time.time;
        startposition = transform.position;
        endposition = startposition + new Vector3(sideforce, 0, forwardforce);
        targetposition = endposition;
    }

    // Disable Movement if Player hits Obstacle
    void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.collider.tag == "Player")
        {
            //Debug.Log("we hit " + collisioninfo.collider.name);
            DisableMovement();
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving)
        {
            //Invert Axis and Update Time
            if ((currentTime + secsToInvertMoveAxis) <= Time.time)
            {
                //Change targetposition
                if (targetposition == endposition)
                {
                    targetposition = startposition;
                }
                else
                {
                    targetposition = endposition;
                }

                currentTime = Time.time;
                //Debug.Log("Changing Sides " + currentTime + "Time: " +Time.time);
            }


            // remember, 10 - 5 is 5, so target - position is always your direction.
            Vector3 dir = targetposition - transform.position;

            // magnitude is the total length of a vector.
            // getting the magnitude of the direction gives us the amount left to move
            float dist = dir.magnitude;

            // this makes the length of dir 1 so that you can multiply by it.
            dir = dir.normalized;

            // the amount we can move this frame
            float move = speed * Time.deltaTime;

            // limit our move to what we can travel.
            if (move > dist) move = dist;

            // apply the movement to the object.
            transform.Translate(dir * move);


            // Add Side Movement
            /*if (sideforce != 0)
            {
                obstacleTransform
                
            }

            // Add Forward Movement
            if (forwardforce != 0)
            {
                
            }
            */


        }
    }


}
