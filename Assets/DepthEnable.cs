using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class DepthEnable : MonoBehaviour
{
    void Awake()
    {
        if (Camera.main.depthTextureMode == DepthTextureMode.None)
        {
            Camera.main.depthTextureMode = DepthTextureMode.Depth;
        }
    }


}
