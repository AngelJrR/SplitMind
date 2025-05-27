using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

using UnityEngine.XR;
using Unity.XR.CoreUtils;
using UnityEngine.UIElements;


[RequireComponent(typeof(InputData))]
public class SecondCamera : MonoBehaviour
{
    private InputData _inputData;

    public GameObject firstPOS;
    Vector3 starting;
    bool moveable = true;

    float x;
    float y;
    float fight = 0;
    public float moveSpeed = .2f;
    public Camera rig;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 144;
        _inputData = GetComponent<InputData>();

        starting = firstPOS.transform.position;
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = firstPOS.transform.rotation;
        //transform.Rotate(0,0,.5f);

        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 movement) || Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
          //  Quaternion yaw = Quaternion.Euler(0, firstPOS.gameObject.transform.eulerAngles.y,0);
          Vector2 movement2 = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                x = Input.GetAxis("Horizontal");
                y = Input.GetAxis("Vertical");
            }
            else
            {
                x = movement.x;
                y = movement.y;
            }
            if (fight == 1 && x > 0)
                    x = 0;

            else if(fight == 2 && x < 0)
                x = 0;
            else if (fight == 3 && y > 0)
                y = 0;
            else if (fight == 4 && y < 0)
                y = 0;
            //            Vector3 direction = yaw * new Vector3(x, 0, y);

            Vector3 direction = x * transform.right + y * transform.forward;
            direction.y = 0;
            //Debug.Log(direction);
            transform.position += (direction * moveSpeed * Time.deltaTime);
           // Debug.Log(transform.forward * movement.y);
                                  //new Vector3 (Mathf.Lerp(-transform.forward, transform.forward, movement.x) * moveSpeed, 0, movement.y * moveSpeed);
           
        }

        /*
        if (moveable)
        {
            this.GetComponent<Rigidbody>().AddForce((starting - firstPOS.transform.position).normalized, ForceMode.Impulse);
         
        }
        */
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        Vector2 dist = collision.transform.position-transform.position;
        Debug.Log(dist);


        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            if (x > 0)
                fight = 1;
            else fight = 2;
        }
        else if (y > 0)
            fight = 3;
        else fight = 4;
        

        // moveable = false;


    }

    private void OnCollisionExit(Collision collision)
    {
        //moveable = true;
      
    }

    private void OnTriggerEnter(Collider other)
    {
        //Vector2 dist = other.transform.position - transform.position;
        //Debug.Log(dist);
        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            if (x > 0)
                fight = 1;
            else fight = 2;
        }
        else if (y > 0)
            fight = 3;
        else fight = 4;


    }

    private void OnTriggerExit(Collider other)
    {
        fight = 0;
        
    }


    void doubleCheck()
    {
        //Vector3 direction = x * transform.right + y * transform.forward;

       // if(transform.position.x - 0)
      //  transform.position = new Vector3(transform.position.x, 1f, transform.position.z);

    }
}

