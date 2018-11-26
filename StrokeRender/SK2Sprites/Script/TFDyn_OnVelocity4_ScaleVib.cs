using UnityEngine;
using System.Collections;

public class TFDyn_OnVelocity4_ScaleVib : TFDynamics
{
    public Vector3 _BaseScale = Vector3.zero;
    public Vector3 _ScaleAmp = Vector3.one;

    public Vector3 _RotOnVelEuler = Vector3.forward;
    private Quaternion _RotOnVelQuat;

    // Use this for initialization
    void Start()
    {
        _RotOnVelQuat = Quaternion.Euler(_RotOnVelEuler);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = GetVelocity();

        Vector3 vibFreq = _RotOnVelQuat * vel;

        Vector3 scl = Vector3.zero;
        for (int i = 0; i < 3; i++)
        {
            scl[i] = _ScaleAmp[i] *
                Mathf.Sin(vibFreq[i]*Time.realtimeSinceStartup) 
                                         + _BaseScale[i];
        }

        transform.localScale = scl;
    }


}
