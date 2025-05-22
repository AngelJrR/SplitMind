using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WakeUp : MonoBehaviour, I_Solvy
{

    public TMP_Text text;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void solve(bool solved)
    {
        if (solved)
            text.gameObject.SetActive(true);
    }
}
