using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Stroke 
{
    private static float _MinDistSqr = 0.1f;
    private static float _MinDT = 0.01f;
    private static int _SmoothStep = 4;

    public List<Vector3> _Pos = new List<Vector3>();
    public List<float> _Time = new List<float>();
   
    public List<Vector3> _Velocity = new List<Vector3>();


    public Vector3 GetPos(float idf)
    {
        Vector3 pos = Utils.SampleFromV3List(_Pos, idf);
        return pos;
    }

    public Vector3 GetVecocity(float idf)
    {
        Vector3 vel = Utils.SampleFromV3List(_Velocity, idf);
        return vel;
    }

    public static void SetMinDistSqr(float mdSqr)
    {
        _MinDistSqr = mdSqr;
    }

    public static void SetMinDT(float dt)
    {
        _MinDT = dt;
    }

    public static void SetSmoothStep(int smoothStep)
    {
        _SmoothStep = smoothStep;
    }

    public int GetSampleCount()
    {
        return _Pos.Count;
    }

    public void AddSample(Vector3 pos, float time)
    {
        bool bDistOK = MoveEnough(pos);
        bool bPassedTimeOk = TimePassedEnough(time);
        if(!(bDistOK && bPassedTimeOk))
        {
            return;
        }
        _Pos.Add(pos);
        _Time.Add(time);

        if(_Pos.Count == _SmoothStep+1)
        {
            for (int i = 0; i < _SmoothStep+1;i++)
            {
                NewVelocity();
            }
        }
        else if(_Pos.Count>_SmoothStep+1)
        {
            NewVelocity();
        }

        

    }

    private void NewVelocity()
    {
        Vector3 vel = ComputeVelocity();
        _Velocity.Add(vel);
    }

    private Vector3 ComputeVelocity()
    {
        int idStart = _Pos.Count - _SmoothStep - 1;
        int idEnd = _Pos.Count - 1;
        Vector3 posStart = _Pos[idStart];
        Vector3 posEnd = _Pos[idEnd];
        Vector3 move = posEnd - posStart;
        Vector3 vel = move / (_Time[idEnd] - _Time[idStart]);
        return vel;
    }

    private bool MoveEnough(Vector3 pos){
        if (_Pos.Count > 0)
        {
            Vector3 lastPos = _Pos[_Pos.Count - 1];
            Vector3 offset = pos - lastPos;
            if (offset.sqrMagnitude < _MinDistSqr)
            {
                return false;
            }
        }

        return true;
    }

    private bool TimePassedEnough(float time)
    {
        if (_Time.Count > 0)
        {
            float lastTime = _Time[_Time.Count - 1];
            float dt = time - lastTime;
            if (dt < _MinDT)
            {
                return false;
            }
        }
        return true;
    }




}
