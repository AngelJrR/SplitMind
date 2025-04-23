using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Diamond : MonoBehaviour
{

    public int health = 20;
    float lerpy = 1;
    public Material material;
    float where = 0;

    // Start is called before the first frame update
    void Start()
    {
        lerpy =  (1f / health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null) 
        {
            health--;
            where += lerpy;
            //Debug.Log(where);
            //Debug.Log("Hello");
            material.color = Color.Lerp(Color.cyan, Color.black, where);

            if (health <= 0)
            {
                this.TryGetComponent(out I_Puzzle puzzle);
                puzzle.done(true);
                Destroy(gameObject);
            }
        }

    }
}
