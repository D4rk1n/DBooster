using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Osclate : MonoBehaviour
{
    [Range(0, 1)]
    public float mFactor;
    public float mPeriod=2f;
    public Vector3 mVector= new Vector3(0,10f,0);
    Vector3 initPos;
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        print(initPos.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (mPeriod!=0)
        {
            float cycles = Time.time / mPeriod;
            mFactor = Mathf.Sin(cycles) / 2f + 0.5f;
            transform.position = initPos + mVector * mFactor;
        }
     }

}
