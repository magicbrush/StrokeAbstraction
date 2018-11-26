using UnityEngine;
using System.Collections;

public class LineDynamics : MonoBehaviour
{
    public SK2LR _sk2lr;
    public virtual void UpdateLineRenderer(){


    }

    protected StrokeTracer2 GetStrokeTracer2()
    {
       return _sk2lr.GetSKTraceer2();
    }

}
