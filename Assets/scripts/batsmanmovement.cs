using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class batsmanmovement : MonoBehaviour
{

    Vector3 newPosition;
    Vector3 inipos;
    Quaternion inirot;

    [SerializeField] Button left;
    [SerializeField] Button right;

    public static batsmanmovement batins;

    private void Awake()
    {
        batins = this;
    }

    private bool isRotating = false;
    private Quaternion targetRotation;
    private float rotationDuration = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        inipos = transform.position;
        inirot = transform.rotation;
        right.onClick.AddListener(() =>
        {
            moveRight();
        });
        left.onClick.AddListener(() =>
        {
            moveLeft();
        });
        //InvokeRepeating("moveStart", 2f, 4f);
    }

    void moveLeft()
    {
        newPosition = transform.position + 6 * Vector3.left * Time.deltaTime;

        // Update the object's position
        transform.position = newPosition;
    }

    void moveRight()
    {
        newPosition = transform.position + 6 * Vector3.right * Time.deltaTime;

        // Update the object's position
        transform.position = newPosition;
       
    }

    // Update is called once per frame
    //void Update()
    //{
        
       
    //    //else if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    //{
    //    //    StartRotation(new Vector3(5.741f, -127.967f, 7.436f));
    //    //   // Debug.Log("Left arrow key pressed.");
    //    //}
    //    //else if (Input.GetKeyDown(KeyCode.UpArrow))
    //    //{
    //    //    StartRotation(new Vector3(-82.315f,-59.68f,33.111f));
    //    //   // Debug.Log("Up arrow key pressed.");
    //    //}
    //    //else if (Input.GetKeyDown(KeyCode.RightArrow))
    //    //{
    //    //    StartRotation(new Vector3(-12.47f, 12.9f, 26.791f));
    //    //   // Debug.Log("Right arrow key pressed.");
    //    //}
    //}

    void StartRotation(Vector3 targetDimensions)
    {
        if (!isRotating)
        {
            StartCoroutine(RotateToDimensions(targetDimensions));
        }
    }

    private System.Collections.IEnumerator RotateToDimensions(Vector3 targetDimensions)
    {
        isRotating = true;

        Quaternion initialRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(targetDimensions);

        float elapsedTime = 0f;
        while (elapsedTime < rotationDuration)
        {
            // Calculate the rotation at this point in time
            float t = elapsedTime / rotationDuration;
            Quaternion newRotation = Quaternion.Lerp(initialRotation, targetRotation, t);

            // Apply the rotation to the object
            transform.rotation = newRotation;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final rotation is set precisely
        transform.rotation = targetRotation;

        isRotating = false;
    }

    public void moveStart()
    {
//        Debug.Log("aja wapis");
        transform.position = inipos;
        transform.rotation = inirot;
    }
}
