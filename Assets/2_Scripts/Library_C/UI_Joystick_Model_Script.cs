using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Cargold;


public class UI_Joystick_Model_Script : Cargold.UI.Joystick.UI_Joystick_Model_Script
{
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            base.Init_Func(i);
        }

        base.Activate_Func();
    }

    protected override void OnDragging_Func(Vector2 _vector2)
    {
        base.OnDragging_Func(_vector2);

        // 상 0, 우 90, 하 180, 좌 270
        float _angle = base.GetJoystickAngle_Func();
        this.MovePlayerPos_Func(_vector2.normalized);

        //Debug_C.Log_Func("각도 : " + _angle + " / 스틱 Vector : " + _vector2 + " / 스틱 Vector Normalize : " + _vector2.normalized);
    }

    private void MovePlayerPos_Func(Vector2 _vector2)
    {
        //플레이어 스크립트에 정규화한 값을 넘겨줌.
        //플레이어는 넘겨받은 값 방향으로 특정 속도로 움직임.

        Player_Controller_Script.Instance.Player_Move_Func(_vector2);
    }
}
