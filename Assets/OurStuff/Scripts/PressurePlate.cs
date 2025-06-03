using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.TryGetComponent(out I_Puzzle puzzle);
            puzzle.done(true);
        }

        if (other.gameObject == target)
        {
            this.TryGetComponent(out I_Puzzle puzzle);
            puzzle.done(true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target)
        {
            this.TryGetComponent(out I_Puzzle puzzle);
            puzzle.done(false);
        }
    }
}
