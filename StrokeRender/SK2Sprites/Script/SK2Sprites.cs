using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class SK2Sprites : SKRenderBase
{
    public GameObject _SpritePrefab;
    private StrokeTracer2 _tracer;
    public Transform _TFParent;
    public float _DistDelta = 0.5f;
    public UnityEvent _Delete;
    public UnityEvent _Complete;

    //public List<>

    public override void NewStroke(StrokeTracer2 tracer)
    {
        _tracer = tracer;
    }

    public override void UpdateStroke(StrokeTracer2 tracer)
    {
        if (_tracer != tracer) { return; }



        int count = tracer.GetSampleCount();

        //print(name + " UpdateStroke, count:" + count);

        int idEnd = count-1;
        int idStart = idEnd - 1;
        if (idStart > 0)
        {
            float id0 = (float)idStart;
            float idn = (float)idEnd-0.0001f;
            Vector3 posStart = tracer.GetPos(id0);
            Vector3 posEnd = tracer.GetPos(idn);

            //print("posStart:"+posStart.ToString() + " posEnd:" + posEnd.ToString());
           
            Vector3 Offset = posEnd - posStart;
            float dist = Offset.magnitude;
            float idCount = 1.0f+Mathf.CeilToInt( dist / _DistDelta );

            float interval = (idn - id0) / idCount;
            for (int i = 0; i < idCount; i++)
            {
                float idf = (float)i * interval + id0;

                GameObject newSPObj = 
                    Instantiate(_SpritePrefab, _TFParent) as GameObject;

                TFDynamics[] tfDyns =
                    newSPObj.GetComponents<TFDynamics>();
                foreach(var tfDyn in tfDyns)
                {
                    tfDyn.LinkTracer(tracer, idf);
                }
            }

        }

    }

    public override void DeleteStroke(StrokeTracer2 tracer)
    {
        if (_tracer != tracer) { return; }
        _Delete.Invoke();
    }

    public override void CompleteStroke(StrokeTracer2 tracer)
    {
        if (_tracer != tracer) { return; }
        _Complete.Invoke();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
