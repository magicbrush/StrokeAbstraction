using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Utils : MonoBehaviour
{
    static public Vector3 鼠标位置转换到世界参考系(
        Transform RefObjectTF)
    {
        Vector3 鼠标操作位置InWorld;
        Ray mouseRay = Camera.main.ScreenPointToRay(
            Input.mousePosition);
        float 相机到此物体的z距离 =
            RefObjectTF.position.z -
            Camera.main.transform.position.z;
        鼠标操作位置InWorld =
            mouseRay.GetPoint(相机到此物体的z距离);
        return 鼠标操作位置InWorld;
    }

    static public Vector3 SampleFromV3List(List<Vector3> V3List, float idf)
    {
        if (idf >= 0 && idf < V3List.Count - 1)
        {
            float id0 = Mathf.Floor(idf);
            float id1 = id0 + 1;
            float t = idf - id0;

            Vector3 v0 = V3List[(int)id0];
            Vector3 v1 = V3List[(int)id1];

            Vector3 v = Vector3.Lerp(v0, v1, t);
            return v;
        }
        else
        {
            return Vector3.negativeInfinity;
        }
    }

}
