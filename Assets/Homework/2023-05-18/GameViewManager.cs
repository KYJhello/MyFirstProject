using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameViewManager : MonoBehaviour
{
    private TMP_Text textView;

    private void Awake()
    {
        textView = GetComponent<TMP_Text>();    
    }
    private void OnEnable()
    {
        GameSingleTonManager.GameData.OnShootCountChanged += ChangeText;
    }
    private void OnDisable()
    {
        GameSingleTonManager.GameData.OnShootCountChanged -= ChangeText;
    }

    private void ChangeText(int count)
    {
        textView.text = count.ToString();
    }
}
