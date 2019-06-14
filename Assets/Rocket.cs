using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource audioSource;
    int CurrLvl;
    int NofLvl;
     public float RCSThrust = 100;
     public float mainThrust = 100;
    enum State { Alive,Dead,Next};
    State state= State.Alive;


        
        public AudioClip mainEngine;
        public AudioClip Death;
        public AudioClip Congrats;
 



        public ParticleSystem mainEngineP;
        public ParticleSystem DeathP;
        public ParticleSystem CongratsP;
        public ParticleSystem FireP;


    // Start is called before the first frame update
    void Start()
    {

        CurrLvl = SceneManager.GetActiveScene().buildIndex;
        NofLvl = SceneManager.sceneCountInBuildSettings;
        print(NofLvl);
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (state == State.Alive)
        {
            switch (collision.gameObject.tag)
            {
                case "Friend":
                    {
                        state = State.Alive;
                        break;
                    }
                case "Fuel":
                    {
                        print("Fuel");
                        break;
                    }
                case "Finish":
                    {

                        state = State.Next;
                       
                        CurrLvl = (CurrLvl + 1) % NofLvl;
                        audioSource.Stop();
                        audioSource.PlayOneShot(Congrats);
                        CongratsP.Play();
                        Invoke("NextLevel",1f);
                        break;
                    }
                default:
                    {

                        state = State.Dead;
                        audioSource.Stop();
                        audioSource.PlayOneShot(Death);
                        DeathP.Play();
                        FireP.Play();
                        if (mainEngineP.isPlaying)
                            mainEngineP.Stop();
                        Invoke("Reload", 1f);

                        break;
                    }
            }
        }
    }

    private void NextLevel()
    {
        print(CurrLvl);
        SceneManager.LoadScene(CurrLvl);
    }

    private  void Reload()
    {
        SceneManager.LoadScene(0);
    }

    private void ProcessInput()
    {
        if (state == State.Alive)
        {
            Thrust();

            Rotate();
        }

    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true;
        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward* RCSThrust*Time.deltaTime);
        }
        if (!Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward*RCSThrust*Time.deltaTime);
        }
        rigidBody.freezeRotation = false;
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(mainEngine);
            if(!mainEngineP.isPlaying)
                mainEngineP.Play();
            }
            else
            {
            audioSource.Stop();
            mainEngineP.Stop();
            }
    }
}
