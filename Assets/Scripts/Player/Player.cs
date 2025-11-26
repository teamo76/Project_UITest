using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//컨디션 컨트롤러 를 합칠 껍데기 컴포넌트 연결, 이벤트 통합
public class Player : MonoBehaviour
{
    public PlayerCondition condition;
    public PlayerStats stats;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        condition = GetComponent<PlayerCondition>();
        stats = GetComponent<PlayerStats>();
    }
}
