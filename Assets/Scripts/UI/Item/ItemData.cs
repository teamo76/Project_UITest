using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equiable,
    Cousumable
}
public enum StatType
{
    Atk,
    Def,
    Health,
    Crd
}

[Serializable]
public class ItemDataStat
{
    public StatType Type;
    public int value;
}

//filename = 새파일 이름이 Item
//유니티 메뉴에서 New Item 항목 생성
[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string weaponName;
    public string description;
    public ItemType type;
    public Sprite icon;

    [Header("Stack")]
    public bool canStack;
    public int maxStackAmount;

    [Header("Stat")]
    public ItemDataStat[] statData;
}
