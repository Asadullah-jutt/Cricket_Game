using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    int count = 0;
    movefeilder[] feilder;
    Rigidbody rb;
    public float feilderspeed = 15f;
    public Transform ballpos;
    SphereCollider sphereCollider;
    public static ball ball2ins;
    // private Vector3 start;
    //  movefeilder feilderinstance;
    //public Transform bowler;
    // Start is called before the first frame update
    //private void Start()
    //{
    //    start = ballpos.position;   
    //}
    movefeilder var;
    bool feilderpicked = false;
    Vector3 direction;//= (ballpos.position - other.gameObject.transform.position).normalized;
    Quaternion desiredRotation;//= Quaternion.LookRotation(direction, Vector3.up);
    Vector3 movetopos;
    bool radiusflag = false;
    // Quaternion rot;

    public void resetfeilderpicked()
    {
        feilderpicked = false;
    }
    private void Awake()
    {
        sphereCollider = GetComponent<SphereCollider>();
        ball2ins = this;
        feilder = new movefeilder[10];
    }

    private void OnTriggerStay(Collider other)
    {
        if (feilderpicked == true)
            return;

        if (ballcontroller.ballinstance.is_ball_picked() == true)
        {
            feilderpicked = true;
            direction = (ballpos.position - other.gameObject.transform.position).normalized;
            desiredRotation = Quaternion.LookRotation(direction, Vector3.up);
            // desiredRotation.y = 0;
            rb.MoveRotation(desiredRotation);

            // other.GetComponent<movefeilder>().setdiveflag();
            return;
        }
        if (other.gameObject.tag == "bat")
        {
            if (radiusflag == false)
            {
                radiusflag = true;
                radiusinc();
            }
        }


        if (other.gameObject.tag == "feilder")// && ballcontroller.ballinstance.is_ball_picked() == false)
        {
            var = other.GetComponent<movefeilder>();
            if (check(var.id) == false)
            {
                other.GetComponent<movefeilder>().setflag();
                feilder[count] = var;
                count++;
            }
            //   Debug.Log(other.gameObject.tag);
            rb = other.gameObject.GetComponent<Rigidbody>();
            movetopos = Vector3.MoveTowards(other.gameObject.transform.position, ballpos.position, feilderspeed * Time.deltaTime);
            movetopos.y = 0;
            rb.position = movetopos;
            //  rot = rb.rotation;

            //  Debug.Log(other.gameObject.transform.position);
            // Debug.Log(ballpos.position);
            direction = (ballpos.position - other.gameObject.transform.position).normalized;
            desiredRotation = Quaternion.LookRotation(direction, Vector3.up);
            desiredRotation.x = Quaternion.identity.x;
            desiredRotation.z = Quaternion.identity.z;
            desiredRotation = desiredRotation.normalized;
            //print("qua check " + desiredRotation.normalized);
            rb.MoveRotation(desiredRotation);

            //print("Checkkkakdwkd : " +  feilderinstance);
            //feilderinstance.




        }
        // else

    }

    void radiusinc()
    {
        if (radiusflag == false)
            return;
        if (radiusflag == true)
            sphereCollider.radius++;

        Invoke("radiusinc", 0.1f);

    }

    public void setradius()
    {
        radiusflag = false;
        sphereCollider.radius = 20;
        for (int i = 0; i < count; i++)
        {
            feilder[i].resetflag();
            feilder[i].setpos();
            feilder[i] = null;
        }
 
        Debug.Log(count);
        count = 0;
    }

    bool check(int id)
    {

        for (int i = 0; i < count; i++)
            if (feilder[i].id == id)
                return true;

        return false;
    }







    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Pitch"))
    //    {
    //        //fielder
    //    }
    //    else if (other.CompareTag("30yard"))
    //    {

    //        //fielder
    //    }
    //    else
    //    {
    //        //after entering last collider
    //    }
    //}



}
