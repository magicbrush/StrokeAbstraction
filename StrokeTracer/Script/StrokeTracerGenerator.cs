using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StrokeTracerGenerator : MonoBehaviour
{
    public GameObject _StrokeTracerPrefab;
    public int _mouseBtn = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool bBtnDown = Input.GetMouseButtonDown(_mouseBtn);
        if (bBtnDown)
        {
            GameObject newTracerObj =
                Instantiate(_StrokeTracerPrefab,transform) as GameObject;

            newTracerObj.name ="Stroke_" + Time.realtimeSinceStartup.ToString();
        }
    }

    



}
