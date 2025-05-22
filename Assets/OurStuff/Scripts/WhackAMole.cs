using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WhackAMole : MonoBehaviour, I_Solvy
{
    public List<Transform> spawns = new List<Transform>();
    public GameObject Moles;
    public GameObject Bombs;
    List<int> ints = new List<int>();
    int points = 0;
    I_Puzzle puzzle;



    // Start is called before the first frame update
    void Start()
    {
        puzzle = this.GetComponent<I_Puzzle>();
        
    }

    // Update is called once per frame
    void Update()
    {
    }


    void spawnMoles()
    {
        bool found = true;


        if (ints.Count < 9)
         found = false;
        Vector3 position = new Vector3(0,0,0);
        int index;
        int counting = 0;
        int type;
        index = Random.Range(0, spawns.Count);
        type = Random.Range(0, 2);
        while (!found)
        {
            if (ints.Count == 0)
            {
                ints.Add(index);
                position = spawns[index].position;
                found = true;
                counting = 0;
                GameObject newMole;
                if(type == 0)
                    newMole = Instantiate(Moles, position, Quaternion.identity);
                else newMole = Instantiate(Bombs, position, Quaternion.identity);
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
                GameObject newMole;
                if (type == 0)
                    newMole = Instantiate(Moles, position, Quaternion.identity);
                else newMole = Instantiate(Bombs, position, Quaternion.identity);
                newMole.GetComponent<Mole>().position = index;
                newMole.GetComponent<Mole>().spawny = this;

            }

            if (found)
            {
                
            }
        }
        StartCoroutine(starting());
    }

    IEnumerator starting()
    {
        float timer = Random.Range(0, 2f);
        yield return new WaitForSeconds(timer);

        spawnMoles();
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

    public void solve(bool solved)
    {
        if(solved)
            StartCoroutine(starting());

    }

    public void ChangePoints(int change)
    {
        points += change;
        if (points > 10)
            puzzle.done(true);

    }


}
