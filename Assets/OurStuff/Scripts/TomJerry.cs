using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class TomJerry : MonoBehaviour, I_Solvy
{
    public float size;
    public int type = 0;
    public Vector3 ugh;
    bool once = false;
    public DynamicMoveProvider dyno;
    public DynamicMoveProvider dyno2;
    public SecondCamera secy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.O))
            this.gameObject.SetActive(value: true);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Camera3")
        {
            if (!once)
            {
                if (type == 0)
                {
                    other.transform.position = ugh;
                    dyno.moveSpeed = 1;
                    dyno2.moveSpeed = 1;


                }
                else
                {
                    other.transform.position = ugh;
                    other.GetComponent<SecondCamera>().moveSpeed = .3f;
                    secy.moveSpeed = .3f;
                }

                //once = true;
            }
        }
    }

    public void solve(bool solved)
    {
        this.gameObject.SetActive(value: true);
    }
}
