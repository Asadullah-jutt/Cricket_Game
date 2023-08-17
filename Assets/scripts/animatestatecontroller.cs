using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class animatestatecontroller : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animater;
    int iswalkinghash;
    bool iswalk;
    bool isrun;
    int isrunninghash;
    bool wpressed = false;
    bool lspressed = false;
    int hithash;
    int ghithash;
    int offshothash;
    int legshothash;
    int golfchiphash;
    bool spacepressed = false ;
    bool gpressed = false;
    bool rpressed = false;
    bool tpressed = false;
    bool ypressed = false;
 
    [SerializeField] Button b1;
    [SerializeField] Button b2;
    [SerializeField] Button b3;
    [SerializeField] Button b4;
    [SerializeField] Button b5;

    void Start()
    {
        animater = GetComponent<Animator>();
        iswalkinghash = Animator.StringToHash("isWalking");
        isrunninghash = Animator.StringToHash("isRunning");
        hithash = Animator.StringToHash("hit");
        ghithash = Animator.StringToHash("ghit");
        golfchiphash = Animator.StringToHash("golfhit");
        offshothash = Animator.StringToHash("off");
        legshothash = Animator.StringToHash("leg");
        b1.onClick.AddListener(() =>
        {
            shot1();
        });
        b2.onClick.AddListener(() =>
        {
            shot2();
        });
        b3.onClick.AddListener(() =>
        {
            shot3();
        });
        b4.onClick.AddListener(() =>
        {
            shot4();
        });

        b4.onClick.AddListener(() =>
        {
            shot5();
        });

    }

    void shot1()
    {
        animater.SetBool(hithash, true);
        Invoke("offani", 2f);
        
    }

    void shot2()
    {
        animater.SetBool(ghithash, true);
        Invoke("offani", 2f);


    }

    void shot3()
    {
        animater.SetBool(golfchiphash, true);
        Invoke("offani", 2f);
    }

    void shot4()
    {
        animater.SetBool(legshothash, true);
        Invoke("offani", 2f);
    }

    void shot5()
    {
        animater.SetBool(offshothash, true);
        Invoke("offani", 2f);
    }

    void offani()
    {
        //if (idx == 1)
        //{
            animater.SetBool(hithash, false);
        //}
        //else if (idx == 2)
        //{
            animater.SetBool(ghithash, false);
        //}
        //else if (idx == 3)
        //{
            animater.SetBool(golfchiphash, false);
        //}
        //else if (idx == 4)
        //{
            animater.SetBool(legshothash, false);
        //}
        //else if (idx == 5)
        //{
            animater.SetBool(offshothash, false);
        //}
    }



    // Update is called once per frame
   
}
