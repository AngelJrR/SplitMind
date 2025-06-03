using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{
    public Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Camera3")
        {
            Debug.Log("Wjaofmqwlm");
            other.gameObject.transform.position = position;
            other.gameObject.transform.Rotate(90,0,0);
            other.GetComponent<SecondCamera>().lookingDown = true;
        }
    }
}
