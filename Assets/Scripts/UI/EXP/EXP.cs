using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class EXP : MonoBehaviour
{
 
    public Image uibar;

    public TextMeshProUGUI remainingEXP;

    private PlayerCondition condition;

    private void Start()
    {
        condition = CharacterManager.Instance.Player.condition;
        condition.OnExpChange += ShowExp;
        ShowExp(condition.CurExp, condition.MaxExp);
    }
    public void ShowExp(float curAmount, float maxAmount)
    {
        uibar.fillAmount = curAmount / maxAmount;
        remainingEXP.text = $"{curAmount:F2} / {maxAmount:F2}";
    }
   
}
