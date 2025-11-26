using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//게임 흐름 잡기 
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {//싱글톤
        if(Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
