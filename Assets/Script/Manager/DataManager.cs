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
    public LevelData level = new LevelData();
    public int currentlevel;

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
        LoadLevel();
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
    private void LoadLevel()
    {
        try
        {
            string path = Path.Combine(Application.dataPath, "LevelData.json");
            string jsonData = File.ReadAllText(path);
            level = JsonUtility.FromJson<LevelData>(jsonData);
        }
        catch
        {

        }
    }

    public void UpdateLevel()
    {
        level.levels.Add(new PlayerData(currentlevel));
        level.levels = level.levels.OrderByDescending(_ => _.level).ToList();
        
        string path = Path.Combine(Application.dataPath, "LevelData.json");
        string jsonData = JsonUtility.ToJson(level);
        File.WriteAllText(path, jsonData);
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