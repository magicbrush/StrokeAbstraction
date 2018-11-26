using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TFDyn_OnVelocity : TFDynamics
{
    public float _BaseScale = 0.1f;
    public float _ScaleMultiplier = 1.0f;

   

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos0 = GetPos();
        Vector3 vel = GetVelocity();

        transform.position = pos0;
        transform.localScale = 
            (_BaseScale + _ScaleMultiplier * vel.magnitude) * Vector3.one;
        

    }
}
