using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting
{
    //게임 시작시 해야될 작업
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init()
    {
        if(GameManager.Instance == null)
        {
            GameObject gameManager = new GameObject() { name = "GameManager" };
            gameManager.AddComponent<GameManager>();
        }
    }
}
