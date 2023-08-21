using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    public Button start;
    public Button configuration;
    public Image BGM;

    public void clickconfiguration()
    {
        Debug.Log("환경설정 클릭");
        BGM.gameObject.SetActive(true);
    }

    public void clickClose()
    {
        Debug.Log("환경설정 창 닫기");
        BGM.gameObject.SetActive(false);
    }

    public void clickStart()
    {
        Debug.Log("Story Scene으로 전환");
        SceneManager.LoadScene("StoryLine_Developer");
    }

    public void clickOn()
    {
        Debug.Log("BGM ON");
    }
    public void clickOFF()
    {
        Debug.Log("BGM OFF");
    }
}
