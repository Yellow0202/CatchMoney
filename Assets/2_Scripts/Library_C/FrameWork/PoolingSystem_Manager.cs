using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Cargold;
using Cargold.FrameWork;

public class PoolingSystem_Manager : Cargold.FrameWork.PoolingSystem_Manager
{
    public static new PoolingSystem_Manager Instance;

    [SerializeField] private BasePoolingData<UI_CurveElem_Script> baseCurvePrefab;
    [SerializeField] private BasePoolingData<Item_Script> baseItemPrefab;
    public override void Init_Func(int _layer)
    {
        base.Init_Func(_layer);

        if (_layer == 0)
        {
            Instance = this;

            base.TryGeneratePool_Func<UI_CurveElem_Script>(PoolingKey.UI_CurveData, this.baseCurvePrefab);
            base.TryGeneratePool_Func<Item_Script>(PoolingKey.ItemData, this.baseItemPrefab);
        }
    }
}

public partial class PoolingKey
{
    public const string UI_CurveData = "UI_Curve";
    public const string ItemData = "Item";
}
