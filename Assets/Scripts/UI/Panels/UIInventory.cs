using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//슬롯에 채워진 아이템 정보 띄우기, 효과 적용 등
public class UIInventory : MonoBehaviour
{
    [SerializeField] ItemData[] testItems;
    public ItemSlot[] itemSlots;

    public GameObject infoWindow;
    public Transform slotPanels;

    [Header("Select Item")]
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    public TextMeshProUGUI selectedStatName;
    public TextMeshProUGUI selectedStatValue;
    public GameObject equipButton;
    public GameObject unEquipButton;
    public GameObject deleteButton;

    ItemData selectedItem;
    int selectedItemIndex = 0;

    int curEquipIndex;
    private void Start()
    {
        infoWindow.SetActive(false);
        itemSlots = new ItemSlot[slotPanels.childCount];

        for(int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i] = slotPanels.GetChild(i).GetComponent<ItemSlot>();
            itemSlots[i].index = i;
            itemSlots[i].inventory = this;
        }
        for (int i = 0; i < testItems.Length && i < itemSlots.Length; i++)
        {
            AddItem(i); // testItems[i]를 슬롯에 넣음
        }
        ClearSelecteditemWindow();
    }
    void ClearSelecteditemWindow()
    {
        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;
        selectedStatName.text = string.Empty;
        selectedStatValue.text = string.Empty;

        equipButton.SetActive(false);
        unEquipButton.SetActive(false);
        deleteButton.SetActive(false);
    }
    public void OnSelectItem(int index)
    {
       
        if (itemSlots[index].Item == null)
            return;

        selectedItemIndex = index;
        selectedItem = itemSlots[index].Item;

        selectedItemName.text = selectedItem.weaponName;
        selectedItemDescription.text = selectedItem.description;
        selectedStatName.text = string.Empty;
        selectedStatValue.text = string.Empty;

        for (int i = 0; i < selectedItem.statData.Length; i++)
        {
            selectedStatName.text += selectedItem.statData[i].Type.ToString() + "\n";
            selectedStatValue.text += selectedItem.statData[i].value.ToString() + "\n";

        }
        equipButton.SetActive(!itemSlots[index].equipped);
        unEquipButton.SetActive(itemSlots[index].equipped);
        deleteButton.SetActive(true);
        infoWindow.SetActive(true);
    }

    void AddItem(int index)
    {
        ItemData data  = testItems[index];
        //아이템 중복이 가능한지 판단
        ItemSlot stackslot = GetItemStack(data);
        if (stackslot != null)
        {
            stackslot.quantity++;
            UiUpdate();
            return;
        }
        //비어있는 아이템 슬롯 가져오기
        ItemSlot emptySlot = GetEmptySlot();
        //있으면 넣고
        if(emptySlot != null)
        {
            emptySlot.Item = data;
            emptySlot.quantity = 1;
            UiUpdate();
            return;
        }
        //없으면 삭제
        
    }
    
    void UiUpdate()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if(itemSlots[i].Item != null)
            {
                itemSlots[i].Set();
            }
            else
            {
                itemSlots[i].Clear();
            }
        }
    }

    ItemSlot GetEmptySlot()
    {
        for(int i = 0; i < itemSlots.Length; i++ )
        {
            if( itemSlots[i].Item == null)
            {
                return itemSlots[i];
            }
        }
        return null;
    }

    ItemSlot GetItemStack(ItemData data)
    {
        for(int i = 0;i < itemSlots.Length;i++)
        {
            if(itemSlots[i].Item == data && itemSlots[i].quantity < data.maxStackAmount)
            {
                return itemSlots[i];
            }
        }
        return null;
    }
    void RemoveSelecteditem()
    {
        itemSlots[selectedItemIndex].quantity--;
        if(itemSlots[selectedItemIndex].quantity <= 0)
        {
            selectedItem = null;
            itemSlots[selectedItemIndex].Item = null;
            selectedItemIndex = -1;
            ClearSelecteditemWindow();
        }
        UiUpdate();
    }
    public void OnEquipButton()
    {
        if (itemSlots[curEquipIndex].equipped)
        {
            UnEquip(curEquipIndex);
        }

        itemSlots[selectedItemIndex].equipped = true;
        curEquipIndex = selectedItemIndex;
        EquipmentManager.Instance.EquipNew(selectedItem);
        UiUpdate();

        OnSelectItem(selectedItemIndex);
    }

    void UnEquip(int index)
    {
        itemSlots[index].equipped = false;
        EquipmentManager.Instance.UnEquip();
        UiUpdate();

        if(selectedItemIndex == index)
        {
            OnSelectItem(selectedItemIndex);
        }
    }
    public void OnUnEquipButton()
    {
        UnEquip(selectedItemIndex);
    }
}
