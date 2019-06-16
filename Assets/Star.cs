using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Star : MonoBehaviour
{
    public ParticleSystem StarP;

    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * 125 * Time.deltaTime);
  
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StarP.Play();
           
           
           // Invoke("dDestroy", 0.5f);
        }
    }

    private void dDestroy()
    {
        Destroy(gameObject);
    }


}
