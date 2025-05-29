using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AlphabetCode : MonoBehaviour
{

    int position = 0;
    public int goal;
    public TMP_Text text;
    List<string> codes = new List<string>();
    

    // Start is called before the first frame update
    void Start()
    {
        codes.Add("A" + "B" + "C" + "D" + "E" + "L" + "M" + "N" + "O" + "P");
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
        text.text = codes[position];

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