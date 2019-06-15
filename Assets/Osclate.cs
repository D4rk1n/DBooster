using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Osclate : MonoBehaviour
{
    [Range(0, 1)]
    public float mFactor;
    public float mRange = 20;
    Vector3 mVector;
    Vector3 initPos;
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        print(initPos.ToString());
        mVector = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = initPos + mVector * mFactor * mRange ;
        print(transform.position.ToString());
    }
}
