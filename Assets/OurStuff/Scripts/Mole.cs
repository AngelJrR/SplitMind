using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    public int position;
    public WhackAMole spawny;
    public int type;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(rise());
        if(type == 1)
            StartCoroutine(bomb());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator rise()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.position += transform.up * .05f; 
            yield return new WaitForSeconds(.01f);
        }

    }

    IEnumerator bomb()
    {
        
            yield return new WaitForSeconds(5f);
        spawny.removeNum(position);

        Destroy(gameObject);

    }


    private void OnCollisionEnter(Collision collision)
    {
        spawny.removeNum(position);
        if (type == 1)
        {
            Debug.Log("Idiot");
            spawny.ChangePoints(-1);
        }
        else
            spawny.ChangePoints(1);

        Destroy(gameObject);
    }
}
