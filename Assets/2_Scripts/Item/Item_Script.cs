using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;    //오딘 활용을 위한 추가 부분
using Cargold;
using Cargold.CurveSystem;
using Cargold.PoolingSystem;
using Cargold.Infinite;

public class Item_Script : MonoBehaviour, IPooler
{
    [SerializeField, LabelText("아이템 타입"), ReadOnly] private ItemType itemType;
    [SerializeField, LabelText("움직일 아이템")] private Transform itemTr;

    [LabelText("타겟")] private Transform targetTr;
    [LabelText("타겟 온 코루틴 데이터")] private CoroutineData targetCorData;

    public void InitializedByPoolingSystem()
    {
        this.Init_func();
    }

    public void Init_func()
    {
        //this.curvedClass = new CurvedClass(this.transform, this.Calldel_curveArrive_Func, UI_Curve_Manger.Instance);
        //this.Deacitivate_Func(true);
    }

    public void Deacitivate_Func(bool _isInit = false)
    {
        if (_isInit == false)
        {
            PoolingSystem_Manager.Instance.Despawn_Func(PoolingKey.ItemData, this);
        }

        this.gameObject.SetActive(false);
    }

    public void Item_Setting_Func(Item_InfoData a_ItemData = null)
    {
        this.itemType = ItemType.Gold;
    }

    public void Item_Get_Func()
    {
        Debug.Log("아이템 얻음");

        //임시로 호출
        this.Item_Setting_Func();

        this.targetTr = Player_Controller_Script.Instance._player_View._player.transform;
        this.TargetOn_Func();

        //Destroy(this.gameObject);
    }

    private void TargetOn_Func()
    {
        this.targetCorData.StartCoroutine_Func(TargetMove_Cor(), CoroutineStartType.StartWhenStop);
    }

    private IEnumerator TargetMove_Cor()
    {
        while(true)
        {
            //지정된 대상을 찾습니다. 해당 대상을 향해 자기자신을 날려보냅니다.
            this.itemTr.position = Vector2.MoveTowards(this.itemTr.position, this.targetTr.position, 3 * Time.deltaTime);

            if(this.itemTr.position.x == this.targetTr.position.x &&
               this.itemTr.position.y == this.targetTr.position.y)
            {
                break;
            }

            yield return null;
        }

        //아이템 효과 발동
        if(this.itemType == ItemType.Gold)
        {
            UserSystem_Manager.Instance.wealth.TryGetWealthControl_Func(UserSystem_Manager.WealthControl.Earn, WealthType.Gold, 100);

            Debug.Log("골드 : " + UserSystem_Manager.Instance.wealth.GetQuantity_Func(WealthType.Gold));
        }

        this.Deacitivate_Func();
    }
}
