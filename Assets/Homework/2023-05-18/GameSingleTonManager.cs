using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. 싱글톤 게임메니저 구현
public class GameSingleTonManager : MonoBehaviour
{
    public const string DefaultName = "GameManager";

    private static GameSingleTonManager instance;
    private static GameDataManager gameDataManager;

    // 1-3) 전역에 접근가능하도록
    public static GameSingleTonManager Instance { get { return instance; } }  
    public static GameDataManager GameData { get { return gameDataManager; } }

    private void Awake()
    {
        // 1-2) 씬이 하나만 게임에 유지되도록
        if(instance != null)
        {
            Debug.LogWarning("GameSingleTonInstance: valid instance already registred.");
            Destroy(this);
            return;
        }
        instance = this;
        // 1-1) 씬이 바뀌어도 유지되도록
        DontDestroyOnLoad(this);
        
    }
    private void OnDestroy()
    {
        if(instance == this) { instance = null; }
    }
    private void InitManagers()
    {
        //GameDataManager init
        GameObject gameDataObj = new GameObject() { name = "GameDataManager" };
        gameDataObj.transform.SetParent(transform);
        gameDataManager = gameDataObj.AddComponent<GameDataManager>();
    }

}
