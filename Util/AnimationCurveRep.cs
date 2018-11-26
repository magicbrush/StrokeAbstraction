using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationCurveRep : MonoBehaviour
{
    public List<AnimationCurve> _AnimationCurves =
        new List<AnimationCurve>();

    public AnimationCurve GetACurve(int id)
    {
        if(id>=0 && id<_AnimationCurves.Count)
        {
            return _AnimationCurves[id];
        }
        else
        {
            return null;
        }


    }


}
