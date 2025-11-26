using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float atk = 5f;
    [SerializeField] private float def = 10f;
    [SerializeField] private float health = 100f;
    [SerializeField] private float criticalDamage= 7f;

    public float Atk => atk;
    public float Def => def;
    public float Health => health;
    public float CriticalDamage => criticalDamage;

    public event Action OnStatsChanged;

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
}
