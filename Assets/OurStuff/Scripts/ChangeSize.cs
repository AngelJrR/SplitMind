using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    public float size;
    public int type = 0;
    public Transform ugh;
    bool once = false;

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
        if (other.gameObject.tag == "Player")
        {
            if (!once)
            {
                if (type == 0)
                {
                    ugh.transform.position = new Vector3(other.transform.position.x, .5f, other.transform.position.z);

                    other.GetComponent<CharacterController>().radius = .05f;
                    other.GetComponent<CharacterController>().height = .5f;
                   // other.GetComponent<XROrigin>().transform.position -= transform.up * .5f;
                }
                else
                {
                    ugh.transform.position = new Vector3(other.transform.position.x, 2f, other.transform.position.z);

                    other.GetComponent<CharacterController>().radius = .1f;
                    other.GetComponent<CharacterController>().height = 1;
                    //other.GetComponent<XROrigin>().transform.position += transform.up * .5f;
                }
                once = true;
            }
          //  other.gameObject.transform.localScale = transform.localScale * size;
        }
    }
}
