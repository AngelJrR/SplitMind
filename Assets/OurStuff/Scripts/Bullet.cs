using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 ugh;

    // Start is called before the first frame update
    void Start()
    {
      //  transform.rotation = Quaternion.Euler(ugh);
        StartCoroutine(deletSelf());    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.up * Time.deltaTime * 30;
    }

    IEnumerator deletSelf()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
      //  if (other.gameObject.CompareTag("KillMe"))
         //   Destroy(other.gameObject);
    }
}
