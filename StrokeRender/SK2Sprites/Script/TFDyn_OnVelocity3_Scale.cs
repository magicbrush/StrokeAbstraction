using UnityEngine;
using System.Collections;

public class TFDyn_OnVelocity3_Scale : TFDynamics
{
    public Vector3 _BaseScale = Vector3.zero;
    public Vector3 _Scaler = Vector3.one;
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
        //Vector3 pos0 = GetPos();
        Vector3 vel = GetVelocity();

        Vector3 velR = _RotOnVelQuat * vel;

        Vector3 scl = Vector3.zero;
        for (int i = 0; i < 3;i++)
        {
            scl[i] = _Scaler[i] * velR[i] + _BaseScale[i];
        }

        transform.localScale = scl;
    }
}
