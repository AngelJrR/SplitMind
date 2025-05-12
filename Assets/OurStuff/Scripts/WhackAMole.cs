using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhackAMole : MonoBehaviour
{
    public List<Transform> spawns = new List<Transform>();
    public GameObject Moles;
    List<int> ints = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
            spawnMoles();
    }


    void spawnMoles()
    {
        bool found = true;
        if (ints.Count < 9)
         found = false;
        Vector3 position = new Vector3(0,0,0);
        int index;
        int counting = 0;
        index = Random.Range(0, spawns.Count);

        while (!found)
        {
            if (ints.Count == 0)
            {
                ints.Add(index);
                position = spawns[index].position;
                found = true;
                counting = 0;
                GameObject newMole = Instantiate(Moles, position, Quaternion.identity);
                newMole.GetComponent<Mole>().position = index;
                newMole.GetComponent<Mole>().spawny = this;
            }
            else
            {
                foreach (int i in ints)
                {
                    if (i == index)
                    {
                        index = Random.Range(0, spawns.Count);
                        counting = 0;
                        break;
                    }
                    else { counting++; }


                }
            }
            if (counting == ints.Count)
            {
                ints.Add(index);
                position = spawns[index].position;
                found = true;
                counting = 0;
                GameObject newMole = Instantiate(Moles, position, Quaternion.identity);
                newMole.GetComponent<Mole>().position = index;
                newMole.GetComponent<Mole>().spawny = this;

            }

            if (found)
            {
                
            }
        }
       
    }

    public void removeNum(int posi)
    {
        ints.Remove(posi);
        /*
        foreach(int i in ints)
        { 
           if(posi == ints[i])
           ints.Remove(i);
        }
        */
    }
}
