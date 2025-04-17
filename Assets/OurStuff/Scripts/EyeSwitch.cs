using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera first;
    public Camera second;
    public int timer = 5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void switching()
    {
        StartCoroutine(Nintendoswitch());
    }

    IEnumerator Nintendoswitch()
    {
        if (first.enabled)
        {
            first.enabled = false;
            second.enabled = true;
        }
        else
        {
            first.enabled = true;
            second.enabled = false;
        }
        yield return new WaitForSeconds(timer);
        StartCoroutine(Nintendoswitch());

    }
}
