using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bottles : MonoBehaviour
{

    public int position;
    public GunAMole spawny;
    public int type;
    public Collider col;

    // Start is called before the first frame update
    void Start()
    {

        if (type == 1)
        {
            StartCoroutine(hitbox());
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            spawny.removeNum(position);
            if (type == 1)
            {
                Debug.Log("Idiot");
                //  spawny.ChangePoints(-1);
            }
            else
            {
                spawny.ChangePoints(1);
                Destroy(gameObject);

            }

        }
    }




    private void OnCollisionEnter(Collision collision)
    {
       
    }

    
    
    

    IEnumerator hitbox()
    {
        yield return new WaitForSeconds(.5f);
        col.enabled = true;
    }
}
