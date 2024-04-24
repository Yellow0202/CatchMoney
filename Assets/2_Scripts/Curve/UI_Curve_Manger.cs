using Cargold.Infinite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;    //오딘 활용을 위한 추가 부분
using Cargold;
using Cargold.CurveSystem;

public class UI_Curve_Manger : Cargold.CurveSystem.CurveSystemInfinite
{
    public static UI_Curve_Manger Instance;

    public override void Init_Func(int _layer)
    {
        if(_layer == 0)
        {
            Instance = this;
        }

        base.Init_Func(_layer);
    }

    //public void OnCurve_Func(WealthType _wealthType, Infinite _quantity, Transform _beginPos)
    //{
    //    Vector2 _arrivePos = new Vector2(); //목적지

    //    base.OnCurve_Func(_quantity, 5, _arrivePos, (_quantity) =>
    //    {
    //        UI_CurveElem_Script _curveElemClass = PoolingSystem_Manager.Instance.Spawn_Func<UI_CurveElem_Script>("커브 프리팹 이름");
    //        _curveElemClass.Setting_Func(_wealthType, _quantity, _beginPos);
    //        _curveElemClass.transform.position = _beginPos.position;

    //        return _curveElemClass.GetCurvedClass;
    //    });
    //}

    public void OnCurveitem_Func(ItemType _ItemType, Infinite _quantity, Transform _beginPos)
    {
        //Vector2 _arrivePos = Player_Controller_Script.Instance._player_View._player.transform.position; //목적지

        base.OnCurve_Func(_quantity, 5, Player_Controller_Script.Instance._player_View._player.transform.position, (_quantity) =>
        {
            UI_CurveElem_Script _curveElemClass = PoolingSystem_Manager.Instance.Spawn_Func<UI_CurveElem_Script>(PoolingKey.UI_CurveData);
            _curveElemClass.Setting_Func(_ItemType, _quantity, _beginPos);
            _curveElemClass.transform.position = _beginPos.position;

            return _curveElemClass.GetCurvedClass;
        });
    }
}
