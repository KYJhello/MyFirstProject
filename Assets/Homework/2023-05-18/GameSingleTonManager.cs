using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. �̱��� ���Ӹ޴��� ����
public class GameSingleTonManager : MonoBehaviour
{
    public const string DefaultName = "GameManager";

    private static GameSingleTonManager instance;
    private static GameDataManager gameDataManager;

    // 1-3) ������ ���ٰ����ϵ���
    public static GameSingleTonManager Instance { get { return instance; } }  
    public static GameDataManager GameData { get { return gameDataManager; } }

    private void Awake()
    {
        // 1-2) ���� �ϳ��� ���ӿ� �����ǵ���
        if(instance != null)
        {
            Debug.LogWarning("GameSingleTonInstance: valid instance already registred.");
            Destroy(this);
            return;
        }
        instance = this;
        // 1-1) ���� �ٲ� �����ǵ���
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
