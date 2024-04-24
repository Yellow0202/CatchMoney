using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;    //오딘 활용을 위한 추가 부분
using Cargold;
using Cargold.CurveSystem;
using Cargold.PoolingSystem;
using Cargold.Infinite;

public class UI_CurveElem_Script : MonoBehaviour, IPooler
{
    [ShowInInspector, ReadOnly] private CurvedClass curvedClass;
    [ShowInInspector, ReadOnly] private ItemType itemType;
    [ShowInInspector, ReadOnly] private Infinite quantity;

    [LabelText("시작지점")] private Transform tanghuluTr;

    [SerializeField, LabelText("렌더러 컴포넌트")] private SpriteRenderer itemRenderer;
    [SerializeField, LabelText("스케일 크기")] private Vector3 myScale;

    public CurvedClass GetCurvedClass => this.curvedClass;

    public void InitializedByPoolingSystem()
    {
        this.Init_func();
    }

    public void Init_func()
    {
        this.curvedClass = new CurvedClass(this.transform, this.Calldel_curveArrive_Func, UI_Curve_Manger.Instance);
        this.Deacitivate_Func(true);
    }

    //public void Setting_Func(WealthType _wealthType, Infinite _quantity, Transform a_TanghuluTr)
    //{
    //    this.gameObject.SetActive(true);

    //    this.wealthType = _wealthType;
    //    this.quantity = _quantity;
    //    this.tanghuluTr = a_TanghuluTr;

    //    this.transform.localScale = this.myScale;

    //    //if (_wealthType == WealthType.Gold)
    //    //    this.wealthIcon.sprite = DataBase_Manager.Instance.GetTable_DeFine._wealthTypeGoldIconSprite;
    //    ////else if (_wealthType == WealthType.Cash)
    //    ////    this.wealthIcon.sprite = DataBase_Manager.Instance.GetTable_Define.cashSpriteData;
    //    //else
    //    //    Debug_C.Error_Func("CurveElem Error! _wealthType : " + _wealthType);

    //}

    public void Setting_Func(ItemType _ItemType, Infinite _quantity, Transform a_TanghuluTr)
    {
        this.gameObject.SetActive(true);

        this.itemType = _ItemType;
        this.quantity = _quantity;
        this.tanghuluTr = a_TanghuluTr;

        if(_ItemType == ItemType.Gold)
        {
            this.itemRenderer.sprite = DataBase_Manager.Instance.GetTable_Define._sprite_Gold_Item;
        }
        else if(_ItemType == ItemType.Recovery)
        {
            this.itemRenderer.sprite = DataBase_Manager.Instance.GetTable_Define._sprite_Recovery_Item;
        }

        //this.transform.localScale = this.myScale;

        //if (_wealthType == WealthType.Gold)
        //    this.wealthIcon.sprite = DataBase_Manager.Instance.GetTable_DeFine._wealthTypeGoldIconSprite;
        ////else if (_wealthType == WealthType.Cash)
        ////    this.wealthIcon.sprite = DataBase_Manager.Instance.GetTable_Define.cashSpriteData;
        //else
        //    Debug_C.Error_Func("CurveElem Error! _wealthType : " + _wealthType);

    }

    private void Calldel_curveArrive_Func()
    {
        //if(this.wealthType == WealthType.Gold)
        //    MainSceneUiSystem.Instance.Get_Gold_Func(this.quantity, this.tanghuluTr);

        if (this.itemType == ItemType.Gold)
        {
            Debug.Log("골드 얻음");
        }
        else if (this.itemType == ItemType.Recovery)
        {
            Debug.Log("회복 얻음");
        }

        this.Deacitivate_Func();
    }

    public void Deacitivate_Func(bool _isInit = false)
    {
        if(_isInit == false)
        {
            PoolingSystem_Manager.Instance.Despawn_Func(PoolingKey.UI_CurveData, this);
        }

        this.gameObject.SetActive(false);
    }
}
