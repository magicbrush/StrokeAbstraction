using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKRenderBase : MonoBehaviour {

    virtual public void NewStroke(StrokeTracer2 tracer)
    {
        //print("new Stroke");
    }

    virtual public void UpdateStroke(StrokeTracer2 tracer)
    {
        //print("UpdateStroke");
    }

    virtual public void DeleteStroke(StrokeTracer2 tracer)
    {
        //print("DeleteStroke");
    }

    virtual public void CompleteStroke(StrokeTracer2 tracer)
    {
        //print("CompleteStroke");
    }

}
