using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BehMgr : MonoBehaviour
{
    public string _Name;
    public MonoBehaviour _BehPrefabs;
    public Transform _TFParent;

    public void TurnChildBeh(bool bON)
    {
        System.Type type = _BehPrefabs.GetType();
        var behs = _TFParent.GetComponentsInChildren(type,true);
        foreach(var beh in behs){
            MonoBehaviour mbeh = (MonoBehaviour)beh;
            mbeh.enabled = bON;
        }
    }

    [ContextMenu("TurnONChildBehs")]
    public void TurnONChildBehs()
    {
        TurnChildBeh(true);
    }

    [ContextMenu("TurnOFFChildBehs")]
    public void TurnOFFChildBehs()
    {
        TurnChildBeh(false);
    }


}
