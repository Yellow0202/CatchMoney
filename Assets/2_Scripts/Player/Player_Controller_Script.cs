using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Cargold;

public class Player_Controller_Script : MonoBehaviour
{
    public static Player_Controller_Script Instance;

    [SerializeField, LabelText("플레이어 뷰 스크립트")] private Player_View_Script player_View; public Player_View_Script _player_View => this.player_View;
    [SerializeField, LabelText("플레이어 모델 스크립트")] private Player_Model_Script player_Model; public Player_Model_Script _player_Model => this.player_Model;

    #region 플레이어 돈 습득 관련 변수
    [FoldoutGroup("습득 관련"), LabelText("관리 코루틴 데이터")] private CoroutineData getRangeCorData;
    #endregion

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        this.Start_Player_Func();
    }

    public void Start_Player_Func()
    {   //시작시 호출되어 초기값 세팅을 해줄 함수
        this.player_Model.Start_PlayerModel_Func();
        this.player_View.Start_PlayerView_Func();

        this.Player_GetRange_Func();
    }

    public void Player_Move_Func(Vector2 a_Dir)
    {   //플레이어 움직임 함수

        //건네받은 정보를 토대로 해당 방향으로 특정 위치까지 움직임.
        //방향값이 0이 되면 움직임을 멈춤.

        this.player_View._player.transform.Translate(a_Dir * this.player_Model._playerStatus_MoveSpeed * Time.deltaTime);
    }

    #region 플레이어 습득 관련 함수

    private void Player_GetRange_Func()
    {   //플레이어 돈 습득 함수

        //매 프레임 마다 주변에 대상이 있는지 조사하여 행동해야함.
        //업데이트 말고 코루틴 사용할 예정. 코루틴은 데이터를 내가 조정할 수 있으니까.
        this.getRangeCorData.StartCoroutine_Func(this.Player_GetRangeUpdata_Co(), CoroutineStartType.StartWhenStop);
    }

    private IEnumerator Player_GetRangeUpdata_Co()
    {
        //게임 종료 전까지 계속해서 활동.

        while(true)
        {
            //특정 범위 기준 특정 태그 혹은 레이어의 아이템이 있는지 감지하여 해당 아이템의 습득 함수를 실행시킴.

            Collider2D[] cols = Physics2D.OverlapCircleAll(this.player_View._player.transform.position, this.player_Model._playerStatus_GetRange, 1 << 6);

            if (cols.Length > 0)
            {
                for (int i = 0; i < cols.Length; i++)
                {
                    if (cols[i].tag == "Item")
                    {   //이렇게 찾아오는 게 퍼포먼스 먹지 않을까...?
                        cols[i].GetComponent<Item_Script>().Item_Get_Func();
                    }
                }
            }

            yield return null;
        }

        yield return null;
    }

    #endregion
}
