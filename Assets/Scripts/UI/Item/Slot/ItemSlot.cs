using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{//아이템 정보 연결, 장착여부 ,  아이템 순서 , 지워지기 , 채워지기 , 
    public ItemData Item;   

    public Button button;
    public Image icon;
    public TextMeshProUGUI quantityText;
    private Outline outline;

    public UIInventory inventory;

    public int index;
    public int quantity;
    public bool equipped;
    private void Awake()
    {
        outline = GetComponent<Outline>();
    }
    private void OnEnable()
    {
        outline.enabled = equipped;
    }
    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }
    void OnClick()
    {
        inventory.OnSelectItem(index);
    }
    public void Set()
    {
        //아이콘 등록
        icon.gameObject.SetActive(true);
        icon.sprite = Item.icon;
        //갯수 등록
        quantityText.text = quantity > 1 ? quantity.ToString() : string.Empty;

    }
    public void Clear()
    {
        Item = null;
        icon.gameObject.SetActive(false);
        quantityText.text = string.Empty;
    }
}
