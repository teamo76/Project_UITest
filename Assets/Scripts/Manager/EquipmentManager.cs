using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager Instance;

    public Transform handSlot;
    public GameObject curWeaponObject;  //ItemPrf에 스크립트 장착 시 변경 
    public ItemData curWeaponData;

    //private List<ItemData> equipedItems = new List<ItemData>();
    private void Awake()
    {
        Instance = this;
    }

    public void EquipNew(ItemData data)
    {
        if (curWeaponObject != null) 
        { 
            UnEquip();
        }

        curWeaponObject = Instantiate(data.equipPrf, handSlot);
        curWeaponData = data;
        //equipedItems.Add(data);

        AllresetApply();
    }
    public void UnEquip()
    {
        if(curWeaponObject != null)
        {
            Destroy(curWeaponObject);
            curWeaponData = null;
            //equipedItems.RemoveAt(0);
            curWeaponObject = null;

            AllresetApply();
        }
    }
    private void AllresetApply()
    {
        var stat = CharacterManager.Instance.Player.stats;
        stat.ResetStats();

        if(curWeaponData != null)
        {
            stat.ApplyStats(curWeaponData);
        }
        //foreach (var item in equipedItems)
        //{
        //    stat.ApplyStats(item);
        //}

    }
}
