using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Condition , Stats , Controller 를 합칠 껍데기 컴포넌트 연결, 이벤트 통합
public class Player : MonoBehaviour
{
    public PlayerCondition condition;
    public PlayerStats stats;

    //public ItemData ItemData;
    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        condition = GetComponent<PlayerCondition>();
        stats = GetComponent<PlayerStats>();
    }
}
