using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{//UI열고 닫기 관리 
 public static UIManager Instance {  get; private set; }

    private void Awake()
    {//싱글턴
        if(Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

   public void OpenUI(GameObject go)
    {
        //패널 활성화 
        //버튼 비활성화
        PopUI(go,true);

    }
    public void CloseUI(GameObject go)
    {
        //패널 비활성화
        //버튼 활성화
        PopUI (go,false);

    }
    public void PopUI(GameObject go , bool tf)
    {
        if (tf) go.SetActive(true);
        if(!tf) go.SetActive(false);
    }
}
