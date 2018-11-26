using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

[RequireComponent(typeof(LineRenderer))]
public class SK2LR : SKRenderBase
{
    public AnimationCurveRep _ACurveRep;
    public int _ACurveId = 0;
    public UnityEvent _DeleteStroke;
    public UnityEvent _CompleteStroke;
    private StrokeTracer2 _tracer;

    public StrokeTracer2 GetSKTraceer2()
    {
        return _tracer;
    }

    public override void NewStroke(StrokeTracer2 tracer)
    {
        _tracer = tracer;
        UpdateLineRenderer(tracer);

        LineRenderer lr = GetComponent<LineRenderer>();
        AnimationCurve acurve = _ACurveRep.GetACurve(_ACurveId);
        if(acurve!=null)
        {
            lr.widthCurve = acurve;
        }
    }

    public override void UpdateStroke(StrokeTracer2 tracer)
    {
        if(tracer!=_tracer)
        {
            return;
        }
        UpdateLineRenderer(tracer);
    }

    public override void DeleteStroke(StrokeTracer2 tracer)
    {
        if (tracer != _tracer)
        {
            return;
        }
        _DeleteStroke.Invoke();
    }

    public override void CompleteStroke(StrokeTracer2 tracer)
    {
        if (tracer != _tracer)
        {
            return;
        }
        _CompleteStroke.Invoke();
    }

    private void UpdateLineRenderer(StrokeTracer2 tracer)
    {
        if (_tracer != tracer) { return; }
        LineRenderer lr = GetComponent<LineRenderer>();
        lr.positionCount = _tracer.GetSampleCount();
        List<Vector3> poss = _tracer.GetPoses();
        lr.SetPositions(poss.ToArray());
    }

}
