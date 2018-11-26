using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class LineDyn_WidVibOnSpd : LineDynamics
{
    public float _SpdMultiplier = 1.0f;
    public AnimationCurveRep _AnimCurveRep;
    public int _acurveIdOnFreq = 0;
    public int _acurveIdOnPhase = 1;

    public float _BaseWidth = 0.25f;
    public float _WidthAmp = 0.2f;

    public float _FreqMultipler = 1.0f;

    public override void UpdateLineRenderer()
    {
        base.UpdateLineRenderer();

        StrokeTracer2 sktr = GetStrokeTracer2();

        AnimationCurve acurveFreq = 
            _AnimCurveRep.GetACurve(_acurveIdOnFreq);
        AnimationCurve acurvePhase =
            _AnimCurveRep.GetACurve(_acurveIdOnPhase);

        List<Vector3> poss = sktr.GetPoses();
        List<Vector3> vels = sktr.GetVelocitys();

        int posCount = poss.Count;
        int velCount = vels.Count;

        if(posCount!=velCount)
        {
            return;
        }

        LineRenderer lr = GetComponent<LineRenderer>();
        for (int i = 0; i < vels.Count;i++)
        {
            Vector3 pos = poss[i];
            Vector3 vel = vels[i];

            float spd = vel.magnitude;
            float spd2 = spd * _SpdMultiplier;

            float freq = _FreqMultipler * acurveFreq.Evaluate(spd2);
            float phase = acurvePhase.Evaluate(spd2);

            float width = _BaseWidth + _WidthAmp * Mathf.Sin(
                freq * Time.realtimeSinceStartup + phase);





        }




    }
}
