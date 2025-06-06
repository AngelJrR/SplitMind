using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject otherGun;
    bool copying = false;
    Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position - otherGun.transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse2))
            shoot();
        if(copying)
            moveMe();
        else ahhhhh();
    }

    void shoot()
    {
        Instantiate(Bullet, transform.position + transform.up * .1f, transform.rotation);
    }


    void moveMe()
    {
        transform.position = otherGun.transform.position + startingPos;
        transform.rotation = otherGun.transform.rotation;
    }

    void ahhhhh()
    {
    //    transform.rotation = Quaternion.identity;
    }


    public void updateGrab(bool grabbed)
    {
        if(grabbed)
            copying = true;
        else copying = false;
    }


}
