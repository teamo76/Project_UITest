using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cash : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    private PlayerCondition condition;
    private void Start()
    {
        condition = CharacterManager.Instance.Player.condition;
        condition.OnMoneyChange += ShowCurrentMoney;
        ShowCurrentMoney(condition.Money);
    }
    public void ShowCurrentMoney(int curMoney)
    {
       moneyText.text = curMoney.ToString();
    }
}
