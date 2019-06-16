using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Star : MonoBehaviour
{
    public ParticleSystem StarP;
    public AudioClip collect;
    public GameObject meshChild;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(collect);
            //gameObject.SetActive(false);
            meshChild.GetComponent<MeshRenderer>().enabled = false;
            Invoke("dDestroy", 1f);
        }
    }

    private void dDestroy()
    {
        Destroy(gameObject);
    }


}
