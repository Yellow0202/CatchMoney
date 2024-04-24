using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CameraMove_Script : MonoBehaviour
{
    //카메라 드래그 스크립트

    [LabelText("현재 터치 정보")] private Touch touch;
    [LabelText("터치 시작시 위치")] private Vector2 startPos;
    [LabelText("터치 끝 위치")] private Vector2 EndPos;


    private void Update()
    {
        if(Input.touchCount > 0)
        {
            this.touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    break;

                case TouchPhase.Moved:

                    //움직인 만큼 화면을 드래그시킴.

                    break;

                case TouchPhase.Stationary:
                    break;

                case TouchPhase.Ended:
                    break;
            }
        }
    }
}
