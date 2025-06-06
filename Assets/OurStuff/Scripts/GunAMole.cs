using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UIElements;

public class GunAMole : MonoBehaviour
{
    public List<Transform> spawns = new List<Transform>();
    public GameObject Bottles;
    public GameObject Bombs;
    List<int> ints = new List<int>();
    List<GameObject> objectives = new List<GameObject>();

    int points = 0;
    I_Puzzle puzzle;

    int bombs = 0;

    // Start is called before the first frame update
    void Start()
    {
        puzzle = this.GetComponent<I_Puzzle>();
        spawnMoles();

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
        Vector3 position = new Vector3(0, 0, 0);
        int index;
        int counting = 0;
        float type;
        index = Random.Range(0, 10);
        type = Random.Range(0f, 1f);
        while (!found)
        {
            index = Random.Range(0, 9);

            type = Random.Range(0f, 1f);

            if (ints.Count == 0)
            {
                ints.Add(index);
                position = spawns[index].position;
                counting = 0;
                GameObject newMole;
                if (type >= .3f)
                    newMole = Instantiate(Bottles, position, transform.rotation);
                else newMole = Instantiate(Bombs, position, transform.rotation); bombs++;
                newMole.GetComponent<Bottles>().position = index;
                newMole.GetComponent<Bottles>().spawny = this;
                objectives.Add(newMole);
                Debug.Log(message: "qawodhkwqbkjwqbnd>");

            }
            else if(ints.Count == 9)
                found = true;


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
                //found = true;
                counting = 0;
                GameObject newMole;
                if (type >= .3f)
                    newMole = Instantiate(Bottles, position, transform.rotation);
                else newMole = Instantiate(Bombs, position, transform.rotation); bombs++;
                newMole.GetComponent<Bottles>().position = index;
                newMole.GetComponent<Bottles>().spawny = this;
                objectives.Add(newMole);
                Debug.Log(message: "qawodhkwqbkjwqbnd");
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



    public void ChangePoints(int change)
    {
        points += change;
        if (change < 0)
        {
            foreach (GameObject i in objectives)
                Destroy(i);
            ints.Clear();
            spawnMoles();
            points = 0;
        }
        if (points == 9-bombs)
            puzzle.done(true);

    }


}


