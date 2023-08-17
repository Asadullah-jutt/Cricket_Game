using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movefeilder : MonoBehaviour
{
    // Start is called before the first frame update
   // public static movefeilder feilderinstance;
    // Start is called before the first frame update
    int runhash;
    int downdivehash;
    int frontdivehash;
    int updivehash;
    Animator animater;
    Vector3 pos;
    Quaternion angle;
    int fivehash;
    Rigidbody rb;
    public GameObject bb;

    Renderer renderer;
    static int type = 0 ;
    public int id;
    bool actionflag = false;

    public Transform playerpos ;


    private void Awake()
    {
        type++;
        id = type;
        Debug.Log(id);
        // feilderinstance = this;
    }

    void Start()
    {
         rb = GetComponent<Rigidbody>();
         renderer = bb.GetComponent<Renderer>();
        angle = transform.rotation;
        actionflag = false;
        frontdivehash = Animator.StringToHash("fcat");
        updivehash = Animator.StringToHash("up catch");
        renderer.enabled = false;
        animater = GetComponent<Animator>();
        runhash = Animator.StringToHash("run");
        downdivehash = Animator.StringToHash("downpick");
        pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        angle = new Quaternion(transform.rotation.x, transform.rotation.x, transform.rotation.x,Quaternion.kEpsilon);
        fivehash = Animator.StringToHash("dive");
      //  transform.rotation = playerpos.rotation;
    }
    public void setflag()
    {
        //Debug.LogError("DGdweyugfyuiegfyiwg");
      
            animater.SetBool(runhash, true);
            
        
    }
    public void setdowndiveflag()
    {
        if (actionflag == false)
        {
            renderer.enabled = true;
            ballcontroller.ballinstance.balldisable();
            animater.SetBool(downdivehash, true);
            actionflag = true;
            // Invoke("resetflag", 1.5f);
        }
    }
    public void setdiveflag()
    {
        if (actionflag == false)
        {
            ballcontroller.ballinstance.balldisable();
            renderer.enabled = true;
            animater.SetBool(fivehash, true);
            actionflag = true;
        }
      //  Invoke("resetflag", 1.5f);
    }
    public void setfdiveflag()
    {
        if (actionflag == false)
        {
            Debug.Log("fffff");
            ballcontroller.ballinstance.balldisable();
            renderer.enabled = true;
            animater.SetBool(frontdivehash, true);
            actionflag = true;
        }
        //  Invoke("resetflag", 1.5f);
    }
    public void setupdiveflag()
    {
        if (actionflag == false)
        {
            ballcontroller.ballinstance.balldisable();
            renderer.enabled = true;
            animater.SetBool(updivehash, true);
            actionflag = true;
        }
        //  Invoke("resetflag", 1.5f);
    }
    void throwback()
    {
      
        renderer.enabled = false;
        ballcontroller.ballinstance.setpos(bb.transform.position);
     //   ballcontroller.ballinstance.ballenable();
        //   ballcontroller.ballinstance.MoveBallToStart();
        resetflag();
        gamemanager.instance.checkball();
        // resetflag();
    }

    public void setpos()
    {
        Invoke("setposs", 2f);
    }
    void setposs()
    {
        transform.rotation = angle;
        transform.position = pos;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }


    public void resetflag()
    {
        
        animater.SetBool(fivehash, false);
        animater.SetBool(runhash, false);
        animater.SetBool(downdivehash, false);
        animater.SetBool(frontdivehash,false);
        animater.SetBool(updivehash, false);
     //   ballcontroller.ballinstance.ballenable();
        actionflag = false;
       // transform.LookAt(playerpos)
       
       
        // Debug.Log(transform.position);

        // transform.rotation = angle;
        // Debug.Log(transform.position);


    }



    // Update is called once per frame

}
