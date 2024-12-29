using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public DataManager dataManager;
    public void HomeBtn()
    {
        SceneManager.LoadScene(0);
    }
    public void Level1Btn()
    {
        dataManager.currentlevel = 1;
        SceneManager.LoadScene(2);
    }
    public void Level2Btn()
    {
        dataManager.currentlevel = 2;
        Debug.Log("미개발");
    }

}
