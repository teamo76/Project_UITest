using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Player의 상태, 자산 관리
public class PlayerCondition : MonoBehaviour
{
    [SerializeField] private int money = 20000;
    [SerializeField] private int level = 1;
    [SerializeField]private float curExp;
    [SerializeField]private float maxExp = 10;
    public int Money => money;
    public int Level => level;
    public float CurExp => curExp;
    public float MaxExp => maxExp;

    public event Action<int> OnMoneyChange;
    public event Action<float, float> OnExpChange;
    public event Action<int> OnLevelUp;


    public void AddMoney(int amount)
    {
        money += amount;
        OnMoneyChange?.Invoke(money);
    }
    public bool SpendMoney(int amount)
    {
        if (money < amount) return false;
        money -= amount;
        OnMoneyChange?.Invoke(money);
        return true;
    }
    public void AddExp(float amount)
    {
        curExp += amount;
        if (curExp > maxExp)
        {
            curExp -= maxExp;
            LevelUp();
        }
        OnExpChange?.Invoke(curExp, maxExp);
    }
    private void LevelUp()
    {
        //능력치 상향
        maxExp = maxExp * 1.32f;  
        level++;
        OnLevelUp?.Invoke(level);
    }

}
