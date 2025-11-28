using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Player의 능력치에 관한 것 관리
public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float atk = 5f;
    [SerializeField] private float def = 10f;
    [SerializeField] private float health = 100f;
    [SerializeField] private float criticalDamage = 7f;

    public float Atk => atk;
    public float Def => def;
    public float Health => health;
    public float CriticalDamage => criticalDamage;

    public string newName;
    public string newJob;
    public string newDescription;

    //리셋을 위한 값
    private float baseAtk;  
    private float baseDef;
    private float baseHealth;
    private float baseCritical;

    public event Action OnStatsChanged;

    private void Awake()
    {
        baseAtk = atk;
        baseDef = def;
        baseHealth = health;
        baseCritical = criticalDamage;
    }
    public void AddAtk(float amount)
    {
        atk += amount;
        OnStatsChanged?.Invoke();
    }
    public void AddDef(float amount)
    {
        def += amount;
        OnStatsChanged?.Invoke();
    }
    public void AddHealth(float amount)
    {
        health += amount;
        OnStatsChanged?.Invoke();
    }
    public void AddCriticalDamage(float amount)
    {
        criticalDamage += amount;
        OnStatsChanged?.Invoke();
    }

    public void ApplyStats(ItemData data)
    {
        foreach (var stat in data.statData)
        {
            switch (stat.Type)
            {
                case StatType.Atk:
                    AddAtk(stat.value);
                    break;
                case StatType.Def:
                    AddDef(stat.value);
                    break;
                case StatType.Health:
                    AddHealth(stat.value);
                    break;
                case StatType.Crd:
                    AddCriticalDamage(stat.value);
                    break;
            }
        }
    }
    public void ResetStats()
    {
        atk = baseAtk;
        def = baseDef;
        health = baseHealth;
        criticalDamage = baseCritical;

        OnStatsChanged?.Invoke();
    }
}

 