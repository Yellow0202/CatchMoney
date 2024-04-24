using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cargold;
using Sirenix.OdinInspector;
using Cargold.DB.TableImporter;

// 카라리 테이블 임포터에 의해 생성된 스크립트입니다.

public partial class DB_Table_DefineDataGroup
{
    [SerializeField, FoldoutGroup("플레이어"), LabelText("캐릭터 기본 이동속도")] private float player_MoveSpeed_DB; public float _player_MoveSpeed_DB => this.player_MoveSpeed_DB;
    [SerializeField, FoldoutGroup("플레이어"), LabelText("캐릭터 기본 습득범위")] private float player_GetGange_DB; public float _player_GetGange_DB => this.player_GetGange_DB;

    [SerializeField, FoldoutGroup("스프라이트"), LabelText("골드 아이템")] private Sprite sprite_Gold_Item; public Sprite _sprite_Gold_Item => this._sprite_Gold_Item;
    [SerializeField, FoldoutGroup("스프라이트"), LabelText("회복 아이템")] private Sprite sprite_Recovery_Item; public Sprite _sprite_Recovery_Item => this._sprite_Recovery_Item;
    protected override void Init_Project_Func()
    {
        base.Init_Project_Func();

        /* 런타임 즉시 이 함수가 호출됩니다.
         * 이 스크립트는 덮어쓰이지 않습니다.
         * 임의의 데이터 재가공을 원한다면 이 밑으로 코드를 작성하시면 됩니다.
         */
    }

#if UNITY_EDITOR
    public override void CallEdit_OnDataImportDone_Func()
    {
        base.CallEdit_OnDataImportDone_Func();

        /* 테이블 임포트가 모두 마무리된 뒤 마지막으로 이 함수가 호출됩니다.
         * 이 스크립트는 덮어쓰이지 않습니다.
         * 임의의 데이터 재가공을 원한다면 이 밑으로 코드를 작성하시면 됩니다.
         */
    }
#endif

}