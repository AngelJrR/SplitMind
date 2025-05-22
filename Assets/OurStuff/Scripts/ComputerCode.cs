using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComputerCode : MonoBehaviour
{

    int position = 0;
    public int goal;
    public TMP_Text text;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void buttonPress()
    {
        this.TryGetComponent(out I_Puzzle puzzle);
        position++;
        if (position == 10)
            position = 0;
        text.text = position.ToString();

        if (position == goal)
        {
            Debug.Log("whoo");
            puzzle.done(true);
        }
        else
        {
            puzzle.done(false);

        }
    }

  
}