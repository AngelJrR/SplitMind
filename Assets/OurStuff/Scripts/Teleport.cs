using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    int position = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (position == 0)
            {
                transform.position = new Vector3(0, 0, 0);
                position = 1;
            }
           else  if (position == 1)
            {
                transform.position = new Vector3(0, 0, 10);
                position = 0;
            }
        }
    }
}
