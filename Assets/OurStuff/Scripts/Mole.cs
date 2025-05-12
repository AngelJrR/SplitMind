using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    public int position;
    public WhackAMole spawny;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(rise());
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

    private void OnCollisionEnter(Collision collision)
    {
        spawny.removeNum(position);
        Destroy(gameObject);
    }
}
