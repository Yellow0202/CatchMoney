using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CameraMove_Script : MonoBehaviour
{
    //ī�޶� �巡�� ��ũ��Ʈ

    [LabelText("���� ��ġ ����")] private Touch touch;
    [LabelText("��ġ ���۽� ��ġ")] private Vector2 startPos;
    [LabelText("��ġ �� ��ġ")] private Vector2 EndPos;


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

                    //������ ��ŭ ȭ���� �巡�׽�Ŵ.

                    break;

                case TouchPhase.Stationary:
                    break;

                case TouchPhase.Ended:
                    break;
            }
        }
    }
}
