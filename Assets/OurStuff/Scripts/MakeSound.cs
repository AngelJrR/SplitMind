using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSound : MonoBehaviour
{
    public AudioClip halfed;
    public AudioClip solved;
    AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
     aud = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void halfComplete()
    {
        aud.PlayOneShot(halfed);
    }

    public void solvedComplete()
    {
        aud.PlayOneShot(solved);
    }

}
