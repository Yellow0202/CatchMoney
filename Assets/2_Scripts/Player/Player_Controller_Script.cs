using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Cargold;

public class Player_Controller_Script : MonoBehaviour
{
    public static Player_Controller_Script Instance;

    [SerializeField, LabelText("�÷��̾� �� ��ũ��Ʈ")] private Player_View_Script player_View; public Player_View_Script _player_View => this.player_View;
    [SerializeField, LabelText("�÷��̾� �� ��ũ��Ʈ")] private Player_Model_Script player_Model; public Player_Model_Script _player_Model => this.player_Model;

    #region �÷��̾� �� ���� ���� ����
    [FoldoutGroup("���� ����"), LabelText("���� �ڷ�ƾ ������")] private CoroutineData getRangeCorData;
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
    {   //���۽� ȣ��Ǿ� �ʱⰪ ������ ���� �Լ�
        this.player_Model.Start_PlayerModel_Func();
        this.player_View.Start_PlayerView_Func();

        this.Player_GetRange_Func();
    }

    public void Player_Move_Func(Vector2 a_Dir)
    {   //�÷��̾� ������ �Լ�

        //�ǳ׹��� ������ ���� �ش� �������� Ư�� ��ġ���� ������.
        //���Ⱚ�� 0�� �Ǹ� �������� ����.

        this.player_View._player.transform.Translate(a_Dir * this.player_Model._playerStatus_MoveSpeed * Time.deltaTime);
    }

    #region �÷��̾� ���� ���� �Լ�

    private void Player_GetRange_Func()
    {   //�÷��̾� �� ���� �Լ�

        //�� ������ ���� �ֺ��� ����� �ִ��� �����Ͽ� �ൿ�ؾ���.
        //������Ʈ ���� �ڷ�ƾ ����� ����. �ڷ�ƾ�� �����͸� ���� ������ �� �����ϱ�.
        this.getRangeCorData.StartCoroutine_Func(this.Player_GetRangeUpdata_Co(), CoroutineStartType.StartWhenStop);
    }

    private IEnumerator Player_GetRangeUpdata_Co()
    {
        //���� ���� ������ ����ؼ� Ȱ��.

        while(true)
        {
            //Ư�� ���� ���� Ư�� �±� Ȥ�� ���̾��� �������� �ִ��� �����Ͽ� �ش� �������� ���� �Լ��� �����Ŵ.

            Collider2D[] cols = Physics2D.OverlapCircleAll(this.player_View._player.transform.position, this.player_Model._playerStatus_GetRange, 1 << 6);

            if (cols.Length > 0)
            {
                for (int i = 0; i < cols.Length; i++)
                {
                    if (cols[i].tag == "Item")
                    {   //�̷��� ã�ƿ��� �� �����ս� ���� ������...?
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
