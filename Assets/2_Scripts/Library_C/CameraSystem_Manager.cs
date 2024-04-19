using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Cargold;

public class CameraSystem_Manager : Cargold.CameraSystem_Manager
{
    public static new CameraSystem_Manager Instance;

    public override void Init_Func(int _layer)
    {
        if(_layer == 0)
        {
            Instance = this;
        }

        base.Init_Func(_layer);
    }
}
