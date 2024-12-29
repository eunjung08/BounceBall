using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    private static InGameUI instance;
    public GameObject pauseUI;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseBtn();
        }
    }

    public void HomeBtn()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene(2);
    }
    
    public void PauseBtn()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public static InGameUI Instance
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
