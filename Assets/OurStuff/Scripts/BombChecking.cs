using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombChecking : MonoBehaviour
{
    List<int> bom = new List<int>();
    public GunAMole gunner1;
    public GunAMole gunner2;
    public int howMany = 0;
    int whedwajhkd = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addBomb(int bomb)
    {
        bom.Add(bomb);
        Debug.Log("checking");
    }

    public void increaseCount()
    {
        whedwajhkd++;
        if (whedwajhkd == 18)
            countingBombs();
    }

    public void countingBombs()
    {
        foreach (int bomb in bom)
            Debug.Log(bomb);

            int currPos = 0;
        float bombs = 0;
        for (int i = 0; i < bom.Count; i++)
        {
            currPos = bom[i];
            for (int z = i+1; z < bom.Count; z++)
            {
                if (bom[z] == currPos)
                {
                    bombs--;
                    //Debug.Log(bom[z]);
                  //  Debug.Log(bom[currPos]);
                }
            }
            bombs++;
            Debug.Log("adding");
        }
        howMany += (int)(bombs);
       Debug.Log(howMany);

    }

    public List<int> getBomb()
    {
        return bom;
    }

    public void delet()
    {
        bom.Clear();
        gunner1.ChangePoints(-1);
        gunner2.ChangePoints(-1);
        whedwajhkd = 0; 
        howMany = 0;
    }

  
}
