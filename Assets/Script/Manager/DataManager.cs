using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;
    public int currentlevel;
    public int maxlevel;

    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);    
        }
    }
    public void Clear()
    {
        if (currentlevel > maxlevel)
        {
            maxlevel = currentlevel;
        }
    }

    public void LastLevel()
    {
        if(currentlevel==1)
        {
            SceneManager.LoadScene(currentlevel+1);
        }
        if(currentlevel==2)
        {
            Debug.Log("미개발");
        }
    }
    public static DataManager Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }
}
[Serializable]
public class LevelData
{
    public List<PlayerData> levels = new List<PlayerData>();
}
[Serializable]
public class PlayerData
{
    public int level;

    public PlayerData(int level)
    {
        this.level = level;
    }
}