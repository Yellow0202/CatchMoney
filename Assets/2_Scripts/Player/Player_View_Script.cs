using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Cargold;

public class Player_View_Script : MonoBehaviour
{
    [SerializeField, LabelText("플레이어 오브젝트")] private GameObject player; public GameObject _player => this.player;

    public void Start_PlayerView_Func()
    {

    }
}
