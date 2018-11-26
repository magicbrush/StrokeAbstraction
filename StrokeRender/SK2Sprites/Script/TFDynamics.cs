using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TFDynamics : MonoBehaviour
{
    private StrokeTracer2 _tracer;
    private float _idf;

    public void LinkTracer(StrokeTracer2 tracer, float idf){
        _tracer = tracer;
        _idf = idf;
    }

    protected Vector3 GetPos()
    {
        Vector3 pos = _tracer.GetPos(_idf);
        return pos;
    }

    protected Vector3 GetVelocity()
    {
        Vector3 vel = _tracer.GetVelocity(_idf);
        return vel;
    }
}
