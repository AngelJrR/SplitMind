using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour, I_Puzzle
{
    public PuzzleListener Listener;
    bool solved = false;


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
      //  solved = true;
       // done();
    }

    private void OnTriggerExit(Collider other)
    {
       // solved = false;
       // done();
    }

   

    public Puzzle GetPuzzle()
        {return this;}

    public void done(bool solved)
    {
        Listener.check(solved);
    }
}
