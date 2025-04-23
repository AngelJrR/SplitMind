using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Hoop : MonoBehaviour
{

    public int points = 10;
    float lerpy = 1;
    public Material material;
    int where = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null) 
        {
       
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("What's up");
        where++;
        if (where == points)
        {
            this.TryGetComponent(out I_Puzzle puzzle);
            puzzle.done(true);
        }

        /*
              
            where += lerpy;
            Debug.Log(where);
            Debug.Log("Hello");
            material.color = Color.Lerp(Color.cyan, Color.black, where);

            if (health <= 0)
            {
                this.TryGetComponent(out I_Puzzle puzzle);
                puzzle.done(true);
            } 
         */

    }
}
