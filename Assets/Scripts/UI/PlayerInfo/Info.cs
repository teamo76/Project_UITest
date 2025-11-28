using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Info : MonoBehaviour
{
    public TextMeshProUGUI info;
    public TextMeshProUGUI description;

    private PlayerStats Infomation;
    private void Start()
    {
       Infomation = CharacterManager.Instance.Player.stats; //원래라면 palyerstat에서 받아올 예정

        info.text = "먹히기 싫은 알약\n알 약";
        description.text = "진짜 진짜 진짜 진짜 진짜 진짜 씹히기싫다";
    }

    //public void NewName()
    //{
    //    사용자가 이름을 초기화면에서 이름을 넣는 코드
        

    //}
    //public void NewJob()
    //{
    //    //사용자가 이름을 초기화면에서 이름을 넣는 코드 
        
    //}
    //public void NewDescription()
    //{
    //    //직업에 따른 설명
        
    //}
}
