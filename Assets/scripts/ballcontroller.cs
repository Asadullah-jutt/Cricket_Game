using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballcontroller : MonoBehaviour
{

    Rigidbody rb;

    bool hastiped = false;
    int ballcount = 0;
    bool bathit = false;
    bool flag = false;

    bool throwbackflag = false;
    public static ballcontroller ballinstance;
    public int ballspeed = 40;
    Renderer renderer;
    TrailRenderer trail;
    int currentballscore = 0;
    bool feilderhit = false;
    private Vector3 start;
    bool pickedball = false;
    float stopThreshold = 4f;
    public bool is_ball_picked()
    {
        return pickedball;
    }
    public bool flaggetter()
    {
        return flag;
    }

    public void setpickedball()
    {
        pickedball = true;
    }
    public void resetpickedball()
    {
        pickedball = false;
    }
    public int currenthitgetter()
    {
        return currentballscore;
    }
    //int maxtimer = 0;
    private void Awake()
    {
        ballinstance = this;
     
    }




    // Start is called before the first frame update
    void Start()
    {
        trail = GetComponent<TrailRenderer>();
        renderer = GetComponent<Renderer>();
        start = transform.position;
        rb = GetComponent<Rigidbody>();
        //throwball();
    }
    public void setpos(Vector3 x)
    {
        transform.position = x;
    }
    public void ballenable()
    {
        trail.enabled = true;
        renderer.enabled = true;
    }
    public void balldisable()
    {
        trail.enabled = false;
        renderer.enabled = false;
        rb.angularVelocity = Vector3.zero;
    }
    public void newpos()
    {
        transform.position = gamemanager.instance.spawnpos;
        transform.rotation = Quaternion.identity;
    }
    public void MoveBallToStart()
    {
        StartCoroutine(MoveBallCoroutine());

    }

    private IEnumerator MoveBallCoroutine()
    {
        while (transform.position != start)
        {
            transform.position = Vector3.MoveTowards(transform.position, start, ballspeed * Time.deltaTime);
            yield return null;
        }


        // Ball has reached the start position
        // Perform any additional actions or end the function here
    }


    public float swingForce = 10.0f;
    public void throwball()
    {
        throwbackflag = false;
        ball.ball2ins.resetfeilderpicked();
        ballenable();
        flag = false;
        gameObject.transform.position = gamemanager.instance.spawnpos;
        ballcount++;
        pickedball = false;
        Debug.Log("New Ball" + ballcount);

        bathit = false;
        feilderhit = false;

        rb.velocity = Vector3.zero; // Reset the current velocity

        // Apply a forward force to start the ball's motion
        rb.AddForce(-Vector3.forward * ballspeed, ForceMode.Impulse);

        // Apply torque to create the swinging motion
        Vector3 torque = new Vector3(0f, Random.Range(-10f, 10f), 0f) * swingForce;
        rb.AddTorque(torque, ForceMode.Impulse);
        //  newball = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if (throwbackflag == true)
            return;
        //  readyball = false;
        //Debug.Log(Time.realtimeSinceStartup);
      //  Debug.LogError("Checkkkkk  " + collision.gameObject.tag);
        if (collision.gameObject.tag == "wicketcomponent")
        {
            currentballscore = -1;
            //sreadyball = false;
            //   Debug.Log(collision.gameObject.name);
            Vector3 direction = collision.contacts[0].point - transform.position;

            // Normalize the direction vector
            direction.Normalize();

            // Apply force in the direction of the collision
            collision.gameObject.GetComponent<Rigidbody>().AddForce(direction * 1f, ForceMode.Impulse);
        }
        if (collision.gameObject.tag == "bat")
            bathit = true;

        Collider mycol = collision.GetContact(0).otherCollider;
        Debug.Log("Collision detected with child object: " + mycol.gameObject.tag);
        Debug.Log(collision.contactCount);
        if (mycol.gameObject.tag == "ftag" && bathit == true)
        {
            Debug.LogError("came here");
            //if (hastiped == false && bathit == true)
            //{
               
                currentballscore = -1;
                bathit = false;
                collision.gameObject.GetComponent<movefeilder>().setfdiveflag();
                return;
          //  }
            // collision.gameObject.GetComponent<movefeilder>().setdowndiveflag();
        }
        if (mycol.gameObject.tag == "uptag" && bathit == true)
        {
            Debug.LogError("came here");
            //if (hastiped == false && bathit == true)
            //{
               
                currentballscore = -1;
                bathit = false;
                collision.gameObject.GetComponent<movefeilder>().setupdiveflag();
                return;
           // }
            // collision.gameObject.GetComponent<movefeilder>().setdowndiveflag();
        }
        if (collision.gameObject.tag == "feilder")
        {
          

            feilderhit = true;
            setpickedball();
            if (hastiped == false && bathit == true)
            {
                currentballscore = -1;
                bathit = false;
                // collision.gameObject.GetComponent<movefeilder>().setfdiveflag();
                collision.gameObject.GetComponent<movefeilder>().setdiveflag();
                return;
            }
            collision.gameObject.GetComponent<movefeilder>().setdowndiveflag();

        }

        if (collision.gameObject.CompareTag("bigcircle") && bathit == true)
        {
            hastiped = true;
            if (feilderhit)
                currentballscore = 2;
            else
                currentballscore = 3;

            Debug.Log("ON BigCircle");

            //after entering last collider
        }
        else if (collision.gameObject.CompareTag("smallcircle") && bathit == true)
        {
            hastiped = true;
            if (feilderhit)
                currentballscore = 1;
            else
                currentballscore = 2;

            // if()
            //   hastiped = true;
            Debug.Log("ON SmallCircle");

            // return;
            //fielder
        }
        if (collision.gameObject.CompareTag("ballpitch") && bathit == true)
        {
            currentballscore = 0;
            hastiped = true;

            Debug.Log("ON PITCH");
            // return;
        }
        if (collision.gameObject.CompareTag("sfboundary") && bathit == true)
        {
            if (hastiped == true)
            {
                currentballscore = 4;
                // readyball = false;
                Debug.Log("Four");
                // if (flag == false)
                gamemanager.instance.checkball();
                // Ball has stopped
                // flag = true;
            }
            else
            {
                currentballscore = 6;
                //  readyball = false;
                Debug.Log("Six");
                //  if (flag == false)
                gamemanager.instance.checkball();
                // Ball has stopped
                //   flag = true;
            }

        }

    }


}
