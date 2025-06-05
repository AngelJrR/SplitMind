using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;



[RequireComponent(typeof(InputData))]

public class EyeSwitch : MonoBehaviour
{
    // Start is called before the first frame update

    private InputData _inputData;

    public XROrigin first;
    public XROrigin second;
    public Camera firstC;
    public Camera secondC;
    public int timer = 5;
    public GameObject third;
    public GameObject fourth;
    public GameObject Cube1;
    public GameObject Cube2;
    public GameObject where1;
    public GameObject where2;

    bool onFirst = true;

    public GameObject otherrightcamera;
   // public XROrigin org;

    bool blocking = false;
    GameObject which;
    public InputActionReference primaryButton;
    public InputActionReference secondaryButton;

    bool ugh = false;

    public Vector3 leftRes;
    public Vector3 rightRes;

    void Start()
    {
        _inputData = GetComponent<InputData>();

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.P))
          switching();
        if (Input.GetKeyDown(KeyCode.R))
            resetting();
        //if (_inputData._leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out bool pressed) && !ugh)

        if (primaryButton.action.triggered)// && !ugh)
        {
            switching();

            //  ControllerButton.PrimaryButton
            Debug.Log("hello");
           // ugh = true;
        }

        if (secondaryButton.action.triggered)// && !ugh)
        {
            resetting();

            //  ControllerButton.PrimaryButton
            Debug.Log("hello");
            // ugh = true;
        }

        // else ugh = false;



        if (onFirst)
            {
                secondC.transform.SetPositionAndRotation(third.transform.position, firstC.transform.rotation);
            
                fourth.transform.SetPositionAndRotation(firstC.transform.position, firstC.transform.rotation);
                
        }
            else
            {
                third.transform.SetPositionAndRotation(secondC.transform.position, secondC.transform.rotation);
            firstC.transform.SetPositionAndRotation(fourth.transform.position, secondC.transform.rotation);
            
            }
        if(Cube1 != null)
        Cube1.transform.SetPositionAndRotation(where1.transform.position, firstC.transform.rotation);

        if (Cube2 != null)
            Cube2.transform.SetPositionAndRotation(where2.transform.position, secondC.transform.rotation);
       
    }

    void switching()
    {
        StartCoroutine(Nintendoswitch());
    }

    IEnumerator Nintendoswitch()
    {
        /*
         if (first.targetDisplay == 0)
         {
             first.targetDisplay = 1;
             second.targetDisplay = 0;
         }
         else
         {
             first.targetDisplay = 0;
             second.targetDisplay = 1;
         }
        */
       // firstC.transform.rotation = Quaternion.identity;
       // secondC.transform.rotation = Quaternion.identity;
       // third.transform.rotation = Quaternion.identity;
      //  fourth.transform.rotation = Quaternion.identity;
        blocking = true;
        if (onFirst)
        {
            //firstPOS.gameObject.SetActive(true);
            //secondPOS.gameObject.SetActive(false);

            yield return new WaitForSeconds(.4f);

            first.gameObject.SetActive(false);
            third.gameObject.SetActive(false);
            second.gameObject.SetActive(true);
            fourth.gameObject.SetActive(true);
            onFirst = false;
            Cube1.gameObject.SetActive(false);
        
            Cube2.gameObject.SetActive(true);

        }
        else
        {
           // firstPOS.gameObject.SetActive(false);
           // secondPOS.gameObject.SetActive(true);
            yield return new WaitForSeconds(.4f);
            first.gameObject.SetActive(true);
            third.gameObject.SetActive(true);
            second.gameObject.SetActive(false);
            fourth.gameObject.SetActive(false);
            onFirst = true;
            Cube1.gameObject.SetActive(true);
 
            Cube2.gameObject.SetActive(false);
        }
        //yield return new WaitForSeconds(timer);
        //StartCoroutine(Nintendoswitch());

    }


    void resetting()
    {
        first.transform.position = leftRes;
        fourth.transform.position = leftRes;
        second.transform.position = rightRes;
        third.transform.position = rightRes;
        first.transform.rotation = Quaternion.identity;
        fourth.transform.rotation= Quaternion.identity;
        second.transform.rotation= Quaternion.identity;
        third.transform.rotation = Quaternion.identity;
    }

    public void newRes(Vector3 newPos, int which)
    {
        if(which == 0)
        leftRes = newPos;
        else  rightRes = newPos;
    }
}
