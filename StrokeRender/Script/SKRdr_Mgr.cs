using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SKRdr_Mgr : SKRenderBase
{
    public GameObject _SKRdrPrefab;
    public Transform _TFParent;

   //public List<GameObject> _SK2LRObjs = new List<GameObject>();

    public Dictionary<StrokeTracer2, SKRenderBase> _SK2LRDict = 
        new Dictionary<StrokeTracer2, SKRenderBase>();


    public override void NewStroke(StrokeTracer2 tracer)
    {
        // create new 
        GameObject newObj = Instantiate(_SKRdrPrefab, _TFParent) as GameObject;
        newObj.name = "SKRDR_" + Time.realtimeSinceStartup.ToString();
        SKRenderBase skrdr = newObj.GetComponent<SKRenderBase>();
        skrdr.NewStroke(tracer);

        _SK2LRDict[tracer] = skrdr;
    }

    public override void UpdateStroke(StrokeTracer2 tracer)
    {
        if(_SK2LRDict.ContainsKey(tracer))
        {
            _SK2LRDict[tracer].UpdateStroke(tracer);
        }
    }

    public override void DeleteStroke(StrokeTracer2 tracer)
    {
        if (_SK2LRDict.ContainsKey(tracer))
        {
            _SK2LRDict[tracer].DeleteStroke(tracer);
            _SK2LRDict.Remove(tracer);
        }
    }

    public override void CompleteStroke(StrokeTracer2 tracer)
    {
        if (_SK2LRDict.ContainsKey(tracer))
        {
            _SK2LRDict[tracer].DeleteStroke(tracer);
        }
    }



}
