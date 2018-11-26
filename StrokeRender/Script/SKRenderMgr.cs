using UnityEngine;
using System.Collections;

public class SKRenderMgr : SKRenderBase
{
    public SKRenderBase[] _SKRenders;

    override public void NewStroke(StrokeTracer2 tracer)
    {
        base.NewStroke(tracer);

        foreach(var skrdr in _SKRenders)
        {
            skrdr.NewStroke(tracer);
        }
    }

    override public void UpdateStroke(StrokeTracer2 tracer)
    {
        base.UpdateStroke(tracer);

        foreach (var skrdr in _SKRenders)
        {
            skrdr.UpdateStroke(tracer);
        }
    }

    override public void DeleteStroke(StrokeTracer2 tracer)
    {
        base.DeleteStroke(tracer);

        foreach (var skrdr in _SKRenders)
        {
            skrdr.DeleteStroke(tracer);
        }
    }

    override public void CompleteStroke(StrokeTracer2 tracer)
    {
        base.CompleteStroke(tracer);

        foreach (var skrdr in _SKRenders)
        {
            skrdr.CompleteStroke(tracer);
        }
    }


}
