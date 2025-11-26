using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{//아이템 정보 연결, 장착여부 ,  아이템 순서 , 지워지기 , 채워지기 , 
    public Button button;
    public Image icon;
    public Outline outline;

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

    public void Set()
    {
        //아이콘 등록
        //갯수 등록
        //
    }
    public void Clear()
    {

    }
}
