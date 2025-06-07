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

    public BombChecking bb;

    // Start is called before the first frame update
    void Start()
    {
        puzzle = this.GetComponent<I_Puzzle>();
        StartCoroutine(why());
    }

    // Update is called once per frame
    void Update()
    {
    }


    void spawnMoles()
    {
        bool found = true;
        points = 0;


        if (ints.Count < 9)
            found = false;
        Vector3 position = new Vector3(0, 0, 0);
        int index;
        int counting = 0;
        float type;
        index = Random.Range(0, 9);
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
                else { newMole = Instantiate(Bombs, position, transform.rotation); bombs++; bb.addBomb(index); }
                newMole.GetComponent<Bottles>().position = index;
                newMole.GetComponent<Bottles>().spawny = this;
                objectives.Add(newMole);
                bb.increaseCount();
               // Debug.Log(message: "qawodhkwqbkjwqbnd>");

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
                else { newMole = Instantiate(Bombs, position, transform.rotation); bombs++; bb.addBomb(index); }
                newMole.GetComponent<Bottles>().position = index;
                newMole.GetComponent<Bottles>().spawny = this;
                objectives.Add(newMole);
                // Debug.Log(message: "qawodhkwqbkjwqbnd");
                bb.increaseCount();
            }
            if (found)
            {

            }

        }

    }

    IEnumerator why()
    {
        yield return new WaitForSeconds(.5f);
        spawnMoles();
    }

    public void removeNum(int posi)
    {
       // Debug.Log(bom.Count);
        
            foreach (int i in bb.getBomb())
            {
            if (posi == i)
            {
                bb.delet();

                break;
            }
            }
        
    }



    public void ChangePoints(int change)
    {
        points += change;
        Debug.Log(points);
        if (change < 0)
        {
            foreach (GameObject i in objectives)
                Destroy(i);
            ints.Clear();
            StartCoroutine(why());

            points = 0;
            puzzle.done(false);
        }
        if (points == 9 - bb.howMany)
            puzzle.done(true);

    }


}


