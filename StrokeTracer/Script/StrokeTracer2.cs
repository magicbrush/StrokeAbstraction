using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class StrokeTracer2 : MonoBehaviour
{
    public Stroke _stroke = new Stroke();
    public int _MinSampeCount = 10;
    public int _mouseBtn = 0;
    public float _ZBias = 0.0f;

    [System.Serializable]
    public class EventWithStrokeTracer2 : UnityEvent<StrokeTracer2> { };

    public EventWithStrokeTracer2 NewStroke;
    public EventWithStrokeTracer2 UpdateStroke;
    public EventWithStrokeTracer2 StrokeNotComplete;
    public EventWithStrokeTracer2 StrokeComplete;
    public EventWithStrokeTracer2 DeleteStroke;

    //private bool _bMousePressed = false;
    private Vector3 _MousePos = Vector3.negativeInfinity;
    private float _RecordTime = float.NegativeInfinity;
    public float _MinDistSqr = 2.5f;
    public float _MinDT = 0.01f;




    public int GetSampleCount()
    {
        return _stroke.GetSampleCount();
    }

    public List<Vector3> GetPoses()
    {
        return _stroke._Pos;
    }

    public List<Vector3> GetVelocitys()
    {
        return _stroke._Velocity;
    }

    public Vector3 GetPos(float idf)
    {
        return _stroke.GetPos(idf);
    }

    public Vector3 GetVelocity(float idf)
    {
        return _stroke.GetVecocity(idf);
    }


    // Use this for initialization
    void Start()
    {
        Record_MousePos_Time();
        AddNewSampeToLastStroke();
        NewStroke.Invoke(this);
    }

    // Update is called once per frame
    void Update()
    {
        bool bBtnPressed = Input.GetMouseButton(_mouseBtn);
        bool bBtnUp = Input.GetMouseButtonUp(_mouseBtn);
        if (bBtnPressed)
        {
            Vector3 mouseMove = Input.mousePosition - _MousePos;
            float dt = Time.realtimeSinceStartup - _RecordTime;
            if (mouseMove.sqrMagnitude >= _MinDistSqr && dt >= _MinDT)
            {
                AddNewSampeToLastStroke();
            }
        }
        else if (bBtnUp)
        {
            _MousePos = Vector3.negativeInfinity;
            _RecordTime = float.NegativeInfinity;

            if (_stroke.GetSampleCount() < _MinSampeCount)
            {
                StrokeNotComplete.Invoke(this);
            }
            else
            {
                StrokeComplete.Invoke(this);
            }
        }
    }

    private void Record_MousePos_Time()
    {
        _MousePos = Input.mousePosition;
        _RecordTime = Time.realtimeSinceStartup;
    }

    private void AddNewSampeToLastStroke()
    {
        Vector3 mPos = Utils.鼠标位置转换到世界参考系(transform);
        _stroke.AddSample(mPos, Time.realtimeSinceStartup);
        UpdateStroke.Invoke(this);
    }

    public void SetMinDist(float minDist)
    {
        Stroke.SetMinDistSqr(minDist * minDist);
    }

    public void SetMinDT(float minDT)
    {
        Stroke.SetMinDT(minDT);
    }

    public void SetSmoothStep(int smoothStep)
    {
        Stroke.SetSmoothStep(smoothStep);
    }




}
