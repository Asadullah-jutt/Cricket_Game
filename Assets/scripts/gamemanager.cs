using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    public GameObject topcam;
    public GameObject maincam;
    public GameObject movecam;
    public GameObject ballprefab;
    public Vector3 spawnpos;
    public static gamemanager instance;
    public Text score;
    public Text Currenthit;
    [SerializeField] Button camchange;
    int scoree = 0;

     // Reference to the ball's transform
    public float rotationSpeed = 5.0f; // Adjust the rotation speed as needed
    int togle = 0;
    private void LateUpdate()
    {
        // Check if the ball reference is valid
        if (Input.GetKeyDown(KeyCode.V))
        {
            movecam.SetActive(true);
            togle = 2;
        }
        Quaternion targetRotation = Quaternion.LookRotation(ballprefab.transform.position - movecam.transform.position);

        // Smoothly rotate the camera towards the target rotation
        movecam.transform.rotation = Quaternion.Slerp(movecam.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }


    //private object ballinstance;

    // public Vector3 ballspawnpos;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

        CreateBall();
        Invoke("Throwball", 3f);
        camchange.onClick.AddListener(() =>
        {
            toglecam();
        });
    }

    void toglecam()
    {
        if (togle == 1)
        {
            togle = 0;

            topcam.SetActive(true);
            maincam.SetActive(false);
            
        }
        else
        {
            togle = 1;
            topcam.SetActive(false);
            maincam.SetActive(true);
        }
        // Switch to the next camera in the array
        
    }
        

    private void CreateBall()
    {
        // ballprefab.SetActive(false);
        ballprefab.transform.position = spawnpos;
        checkball();
        // InvokeRepeating("Throwball", 7f,7f);
    }
    public void checkball()
    {
        ball.ball2ins.setradius();
        Debug.LogError("Throwd");
        // if(ballcontroller.ballinstance.flaggetter())
        //  Debug.Log("dadi");
        Invoke("Throwball", 2f);

        //Invoke("Throwball", 1f);
        // Throwball();

    }
    void setpos()
    {
        batsmanmovement.batins.moveStart();
        ballcontroller.ballinstance.newpos();
    }
    public void Throwball()
    {
        Debug.Log("dadi22");
        Currenthit.text = ballcontroller.ballinstance.currenthitgetter().ToString();
        scoree = scoree + ballcontroller.ballinstance.currenthitgetter();
        score.text = scoree.ToString();
        setcammain();
        //  ballprefab.gameObject.throw
        //print("CHECK : " + ballcontroller.ballinstance);
        //  ballprefab.SetActive(true);
        //   setpos();

        bowlercontrollerscript.bowlerinstance.throwaction();


        //ballins.throwball();//Destroy(ballprefab, 5f);
    }

    public void setcammain()
    {
        togle = 1;
        topcam.SetActive(false);
        maincam.SetActive(true);
    }
   

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.C))
    //    {
           
    //}
    //private void Update()
    //{
    //    if (ballcontroller.ballinstance.isready() == false)
    //        Invoke("Throwball", 1f);
    //}

    //public void DisableBall()
    //{
    //    ballprefab.SetActive(false);
    //    //Destroy(ballprefab, 5f);
    //}
    //public void EnableBall()
    //{
    //    //ballprefab.trabsform......posirgukgyedgyw
    //    ballprefab.SetActive(true);
    //    //Destroy(ballprefab, 5f);
    //}
}
