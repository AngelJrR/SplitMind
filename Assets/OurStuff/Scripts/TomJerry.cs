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
    public CharacterController chars;
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
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Camera3" || other.gameObject.tag == "Camera4")
        {
            if (!once)
            {
                if (type == 0)
                {
                    other.transform.position = ugh;
                    dyno.moveSpeed = 2.5f;
                    dyno2.moveSpeed = 2.5f;
                    Debug.Log("Lefty");
                    if(other.GetComponent<SecondCamera>() != null)
                    other.GetComponent<SecondCamera>().moveSpeed = 1f;
                    chars.stepOffset += -.1f;


                }
                else
                {
                    other.transform.position = ugh;
                    if (other.GetComponent<SecondCamera>() != null)
                    other.GetComponent<SecondCamera>().moveSpeed = 1f;
                    secy.moveSpeed = 1f;
                    Debug.Log("Rightty");
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
