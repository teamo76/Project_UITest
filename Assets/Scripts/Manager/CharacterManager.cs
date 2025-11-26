using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{//플레이어 전역 관리 
    private static CharacterManager _instance;
    public static CharacterManager Instance { get { return _instance; }}

    private Player _player;

    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this) { Destroy(gameObject); return; }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
