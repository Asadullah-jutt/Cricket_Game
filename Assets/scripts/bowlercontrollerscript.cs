using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowlercontrollerscript : MonoBehaviour
{
    Animator animater;
    int throwballhash;
    public static bowlercontrollerscript bowlerinstance;
    // Start is called before the first frame update

    private void Awake()
    {
        bowlerinstance = this;
    }
    void Start()
    {
        animater = GetComponent<Animator>();
        throwballhash = Animator.StringToHash("throw");
    }
    public void throwaction()
    {
        animater.SetBool(throwballhash, true);
        Invoke("setfalse", 2f);
    }

    void setfalse()
    {
        animater.SetBool(throwballhash, false);
    }


    public void throwball()
    {
        ballcontroller.ballinstance.ballenable();
        ballcontroller.ballinstance.throwball();
    }

   
}
