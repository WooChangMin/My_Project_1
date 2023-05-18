using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private static GameManager instance;
    private static DataManager dataManager;

    public static GameManager Instance { get { return instance; } }
    public static DataManager Data { get { return dataManager; } }
    public void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this);
        instance = this;
        InitManager();
        
    }
    private void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }

    private void InitManager()
    {
        //DataManagerInit
        GameObject dataObj = new GameObject() { name = "DataManager" };
        dataObj.transform.parent = transform;
        dataManager = dataObj.AddComponent<DataManager>();
    }
    /*
    private static GameManager instance;
    private static DataManager dataManager;

    public static GameManager Instance { get { return instance; } }                       //함수
    public static DataManager Data { get { return dataManager; } }  

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this);                          //씬이 변경되는 경우.
        instance = this;
        InitManagers();
    }

    private void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }

    private void InitManagers()
    {
        // DataManager init
        GameObject dataObj = new GameObject() { name = "DataManager" };
        dataObj.transform.SetParent(transform);
        dataManager = dataObj.AddComponent<DataManager>();
    }
    */
}
