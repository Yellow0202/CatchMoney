using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Cargold;

public class Player_Model_Script : MonoBehaviour
{
    #region 플레이어 능력치

    [SerializeField, FoldoutGroup("능력치"), LabelText("최대 체력"), ReadOnly] private float playerStatus_MaxHp;
    public float _playerStatus_MaxHp => this.playerStatus_MaxHp;

    [SerializeField, FoldoutGroup("능력치"), LabelText("현재 체력"), ReadOnly] private float playerStatus_CurHp;
    public float _playerStatus_CurHp => this.playerStatus_CurHp;

    [SerializeField, FoldoutGroup("능력치"), LabelText("플레이어 이동속도"), ReadOnly] private float playerStatus_MoveSpeed;
    public float _playerStatus_MoveSpeed => this.playerStatus_MoveSpeed;

    [SerializeField, FoldoutGroup("능력치"), LabelText("습득 범위"), ReadOnly] private float playerStatus_GetRange;
    public float _playerStatus_GetRange => this.playerStatus_GetRange;

    #endregion

    public void Start_PlayerModel_Func()
    {
        this.playerStatus_MoveSpeed = DataBase_Manager.Instance.GetTable_Define._player_MoveSpeed_DB;
        this.playerStatus_GetRange = DataBase_Manager.Instance.GetTable_Define._player_GetGange_DB;
    }
}
