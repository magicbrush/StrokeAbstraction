using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StrokeTracer : MonoBehaviour
{
    public List<Stroke> _Strokes = new List<Stroke>();

    public int _MinSampeCount = 10;
    public int _mouseBtn = 0;
    public float _ZBias = 0.0f;

    [System.Serializable]
    public class EventWithInt:UnityEvent<int>{};

    [System.Serializable]
    public class EventWithStroke : UnityEvent<Stroke> { };

    public EventWithStroke NewStroke;
    public EventWithStroke UpdateStroke;
    public EventWithStroke StrokeComplete;
    public EventWithStroke DeleteStroke;

    // Use this for initialization
    void Start () {
		
	}

    private bool _bMousePressed = false;
    private Vector3 _MousePos = Vector3.negativeInfinity;
    private float _RecordTime = float.NegativeInfinity;
    public float _MinDistSqr = 2.5f;
    public float _MinDT = 0.01f;

	// Update is called once per frame
	void Update () {

        bool bBtnDown = Input.GetMouseButtonDown(_mouseBtn);
        if(bBtnDown)
        {
            _Strokes.Add(new Stroke());
            NewStroke.Invoke(_Strokes[_Strokes.Count - 1]);
            Record_MousePos_Time();
            AddNewSampeToLastStroke();
            _bMousePressed = true;
        }

        if(!_bMousePressed)
        {
            return;
        }

        bool bBtnPressed = Input.GetMouseButton(_mouseBtn);
        if(bBtnPressed)
        {
            Vector3 mouseMove = Input.mousePosition - _MousePos;
            float dt = Time.realtimeSinceStartup - _RecordTime;
            if(mouseMove.sqrMagnitude>=_MinDistSqr && dt >= _MinDT)
            {
                AddNewSampeToLastStroke();
            }
        }

        bool bBtnUp = Input.GetMouseButtonUp(_mouseBtn);
        if(bBtnUp)
        {
            _MousePos = Vector3.negativeInfinity;
            _RecordTime = float.NegativeInfinity;

            if(_Strokes[_Strokes.Count-1].GetSampleCount()< _MinSampeCount)
            {
                _Strokes.RemoveAt(_Strokes.Count - 1);
            }
            else
            {
                StrokeComplete.Invoke(_Strokes[_Strokes.Count - 1]);
            }
            _bMousePressed = false;
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
        _Strokes[_Strokes.Count-1].AddSample(mPos, Time.realtimeSinceStartup);
        UpdateStroke.Invoke(_Strokes[_Strokes.Count - 1]);
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
