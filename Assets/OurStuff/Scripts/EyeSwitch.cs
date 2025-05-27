using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;



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
    public GameObject Cube;
    bool onFirst = true;

    public GameObject otherrightcamera;
   // public XROrigin org;

    bool blocking = false;
    GameObject which;



    void Start()
    {
        _inputData = GetComponent<InputData>();

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.P))
          switching();
        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.primaryButton, out bool pressed))
        {
            
            Debug.Log("hi"); 
        
        }
            if (onFirst)
            {
                secondC.transform.SetPositionAndRotation(firstC.transform.position, firstC.transform.rotation);
            
                fourth.transform.SetPositionAndRotation(firstC.transform.position, firstC.transform.rotation);
                
        }
            else
            {
                third.transform.SetPositionAndRotation(secondC.transform.position, secondC.transform.rotation);
            firstC.transform.SetPositionAndRotation(secondC.transform.position, secondC.transform.rotation);
            
            }
            /*
            Cube.transform.position = which.transform.position;
            if(first.gameObject != null)
            Cube.transform.rotation = first.transform.rotation;
            else Cube.transform.rotation = second.transform.rotation;
            */
        
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

        }
        yield return new WaitForSeconds(timer);
        //StartCoroutine(Nintendoswitch());

    }



}
