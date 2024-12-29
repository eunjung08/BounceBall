using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public GameObject pause;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeBtn();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            HomeBtn();
        }
    }

    public void HomeBtn()
    {
        SceneManager.LoadScene(0);
    }

    public void ResumeBtn()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene(2);
    }
}
