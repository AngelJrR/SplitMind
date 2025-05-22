using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActivateGravity : MonoBehaviour, I_Solvy
{

    public Rigidbody body;

    public void solve(bool solved)
    {
        if(solved) 
        body.useGravity = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
