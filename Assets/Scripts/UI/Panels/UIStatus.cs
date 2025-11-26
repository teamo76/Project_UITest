using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIStatus : MonoBehaviour
{
    public TextMeshProUGUI atkText;
    public TextMeshProUGUI deftext;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI crDText;

    private PlayerStats stats;
    private void Start()
    {
        stats = CharacterManager.Instance.Player.stats;
        stats.OnStatsChanged += ShowStats;
        ShowStats();
    }
    void ShowStats()
    {
        atkText.text = $"공격력\n{stats.Atk}";
        deftext.text = $"방어력\n{stats.Def}"; 
        healthText.text = $"체력\n{stats.Health}";
        crDText.text = $"치명타\n{stats.CriticalDamage}";
    }
}
