using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;    //���� Ȱ���� ���� �߰� �κ�
using Cargold;
using Cargold.CurveSystem;
using Cargold.PoolingSystem;
using Cargold.Infinite;

public class Item_Script : MonoBehaviour, IPooler
{
    [SerializeField, LabelText("������ Ÿ��"), ReadOnly] private ItemType itemType;
    [SerializeField, LabelText("������ ������")] private Transform itemTr;

    [LabelText("Ÿ��")] private Transform targetTr;
    [LabelText("Ÿ�� �� �ڷ�ƾ ������")] private CoroutineData targetCorData;

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
        Debug.Log("������ ����");

        //�ӽ÷� ȣ��
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
            //������ ����� ã���ϴ�. �ش� ����� ���� �ڱ��ڽ��� ���������ϴ�.
            this.itemTr.position = Vector2.MoveTowards(this.itemTr.position, this.targetTr.position, 3 * Time.deltaTime);

            if(this.itemTr.position.x == this.targetTr.position.x &&
               this.itemTr.position.y == this.targetTr.position.y)
            {
                break;
            }

            yield return null;
        }

        //������ ȿ�� �ߵ�
        if(this.itemType == ItemType.Gold)
        {
            UserSystem_Manager.Instance.wealth.TryGetWealthControl_Func(UserSystem_Manager.WealthControl.Earn, WealthType.Gold, 100);

            Debug.Log("��� : " + UserSystem_Manager.Instance.wealth.GetQuantity_Func(WealthType.Gold));
        }

        this.Deacitivate_Func();
    }
}
