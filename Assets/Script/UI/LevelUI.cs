using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    private DataManager dataManager;
    public Text[] Levels = new Text[10];
    private Text CheckText;
    public int NumChecker;
    public Text[] WhatLevel = new Text[10];

    private void Start()
    {
        dataManager = GameObject.FindGameObjectWithTag("Data").GetComponent<DataManager>();
    }

    private void Update()
    {
        LevelCheck();
    }

    public void LevelCheck()
    {
        for(int i = 0; i < Levels.Length; i++)
        {
            if(dataManager.maxlevel >= i)
            {
                switch (i)
                {
                    case 0:
                        Levels[i].text = "1";
                        continue;
                    case 1:
                        Levels[1].text = "2";
                        continue;
                    default:
                        break;
                }
            }
        }
    }
    public void BtnLevelOne()
    {
        NumChecker = 1;
        CheckIn();
    }
    public void BtnLevelTwo()
    {
        NumChecker = 2;
        CheckIn();
    }
    public void BtnLevelThree()
    {
        NumChecker = 3;
        CheckIn();
    }

    private void CheckIn()
    {
        switch (NumChecker)
        {
            case 1:
                if (WhatLevel[0].text == "1")
                {
                    dataManager.maxlevel = 1;
                    SceneManager.LoadScene(2);
                }
                else
                {
                    Debug.Log("이전 레벨을 클리어하고 오세요!");
                }
                break;
            case 2:
                if (WhatLevel[1].text == "2")
                {
                    dataManager.maxlevel = 2;
                    Debug.Log("Beta 게임이랍니다~");
                }
                else
                {
                    Debug.Log("이전 레벨을 클리어하고 오세요!");
                }
                break;
            default:
                Debug.Log("이전 레벨을 클리어하고 오세요!");
                break;
        }
    }
}
