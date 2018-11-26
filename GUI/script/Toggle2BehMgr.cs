using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle2BehMgr : MonoBehaviour {

    public BehMgr _behMgr;

	public void Turn(bool bON)
    {
        _behMgr.TurnChildBeh(bON);
    }
}
