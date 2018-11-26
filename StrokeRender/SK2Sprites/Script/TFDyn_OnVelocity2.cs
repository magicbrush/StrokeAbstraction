using UnityEngine;
using System.Collections;

public class TFDyn_OnVelocity2 : TFDynamics
{

    public float _BaseScale = 0.1f;
    public float _ScaleMultiplier = 1.0f;

    public Vector3 _RotOnVel;
    private Quaternion _QRotOnVel;

    public AnimationCurveRep _ACurveRep;
    public int _ACurveID_Amp = 0;

    public float _VibrationSpd = 1.0f;
    public float _AmplitudeMultiplier = 1.0f;

    private float _BaseTime = 0.0f;

    // Use this for initialization
    void Start()
    {
        _QRotOnVel = Quaternion.Euler(_RotOnVel);
        _BaseTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos0 = GetPos();
        Vector3 vel = GetVelocity();
        Vector3 vibDir = (_QRotOnVel * vel);

        AnimationCurve acurveAmp = _ACurveRep.GetACurve(_ACurveID_Amp);

        float amplitude = 
            _AmplitudeMultiplier *
            acurveAmp.Evaluate((_BaseTime+Time.realtimeSinceStartup)
                               * _VibrationSpd);

        Vector3 offset = amplitude * vibDir;

        Vector3 pos = pos0 + offset;

        transform.position = pos;
    }
}
