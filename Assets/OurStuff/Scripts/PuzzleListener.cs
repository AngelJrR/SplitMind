using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleListener : MonoBehaviour
{

    public List<Puzzle> puzzles = new List<Puzzle>();
    bool ready = false;
    int allSolved = 0;
    
    public List<GameObject> solver = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        foreach (Puzzle puzzle in puzzles)
        {
            puzzle.Listener = this;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void check(bool solved)
    {
        if(solved)
            allSolved++;
        else allSolved--;

        Debug.Log("cgejcing");

        if (allSolved == puzzles.Count)
        { ready = true;
            Debug.Log("Im ready");
            foreach (GameObject solvy in solver)
            solvy.GetComponent<I_Solvy>().solve(true);
        }

        /*
        int checking = 0;
        foreach (Puzzle puzzle in puzzles)
        {
            puzzle.s;
        }
        if ()
        */
    }
}
