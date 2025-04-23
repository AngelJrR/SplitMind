using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject first;
    public GameObject second;
    public int timer = 5;
    public GameObject firstPOS;
    public GameObject secondPOS;
    public GameObject Cube;
    bool onFirst = true;

    bool blocking = false;
    GameObject which;

    void Start()
    {
        which = firstPOS;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            switching();
        if (blocking)
            Cube.transform.position = which.transform.position;
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
            which = firstPOS;
            onFirst = false;
        }
        else
        {
            which = secondPOS;
            onFirst = true;
        }
        yield return new WaitForSeconds(timer);
        StartCoroutine(Nintendoswitch());

    }
}
