using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level : MonoBehaviour
{
    public TextMeshProUGUI levelText;

    private PlayerCondition condition;
    private void Start()
    {
        condition = CharacterManager.Instance.Player.condition;
        condition.OnLevelUp += ShowLevel;
        ShowLevel(condition.Level);
    }

    private void ShowLevel(int level)
    {
        levelText.text = $"<size=35>Lv.</size><b>{level}</b>";
    }
}
