using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Cargold;

public class Item_Script : MonoBehaviour
{
    public void Item_Get_Func()
    {
        Debug.Log("아이템 얻음");

        //아이템을 얻었을 때 더 이상 감지에 들지 않도록 태그를 바꿔줘야 함.
        //다음 자신을 플레이어 위치까지 끌고 간 다음 도착하면 스스로를 없애주고 결과를 호출해줌.

        //태그를 바꿔주는 것이기에 태그가 이상하게 바뀔 염려가 있음. 태그명을 상수로 관리해줄 곳이 필요함.
    }
}
