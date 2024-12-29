using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneUI : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            LoadLevel();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ExitBtn();
        }
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitBtn()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void LastLevelBtn()
    {
        DataManager.Instance.LastLevel();
    }
}
