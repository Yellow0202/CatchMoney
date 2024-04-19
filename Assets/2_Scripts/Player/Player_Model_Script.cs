using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Cargold;

public class Player_Model_Script : MonoBehaviour
{
    #region �÷��̾� �ɷ�ġ

    [SerializeField, FoldoutGroup("�ɷ�ġ"), LabelText("�ִ� ü��"), ReadOnly] private float playerStatus_MaxHp;
    public float _playerStatus_MaxHp => this.playerStatus_MaxHp;

    [SerializeField, FoldoutGroup("�ɷ�ġ"), LabelText("���� ü��"), ReadOnly] private float playerStatus_CurHp;
    public float _playerStatus_CurHp => this.playerStatus_CurHp;

    [SerializeField, FoldoutGroup("�ɷ�ġ"), LabelText("�÷��̾� �̵��ӵ�"), ReadOnly] private float playerStatus_MoveSpeed;
    public float _playerStatus_MoveSpeed => this.playerStatus_MoveSpeed;

    [SerializeField, FoldoutGroup("�ɷ�ġ"), LabelText("���� ����"), ReadOnly] private float playerStatus_GetRange;
    public float _playerStatus_GetRange => this.playerStatus_GetRange;

    #endregion

    public void Start_PlayerModel_Func()
    {
        this.playerStatus_MoveSpeed = DataBase_Manager.Instance.GetTable_Define._player_MoveSpeed_DB;
        this.playerStatus_GetRange = DataBase_Manager.Instance.GetTable_Define._player_GetGange_DB;
    }
}
