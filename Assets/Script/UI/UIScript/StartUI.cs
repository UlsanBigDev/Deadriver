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
    public UISoundManager uISoundManager;
    public AudioSource bgmPlayer;

    void Awake()
    {
        uISoundManager = FindObjectOfType<UISoundManager>();
    }
    public void clickconfiguration()
    {
        Debug.Log("환경설정 클릭");
        BGM.gameObject.SetActive(true);
        uISoundManager.SfxPlay(UISoundManager.Sfx.click);
    }

    public void clickClose()
    {
        Debug.Log("환경설정 창 닫기");
        BGM.gameObject.SetActive(false);
        uISoundManager.SfxPlay(UISoundManager.Sfx.click);
    }

    public void clickStart()
    {
        Debug.Log("Story Scene으로 전환");
        SceneManager.LoadScene("StoryLine_Developer");
        uISoundManager.SfxPlay(UISoundManager.Sfx.click);
    }

    public void clickOn()
    {
        Debug.Log("BGM ON");
        GlobalSoundManager.isBgmSound = true;
        uISoundManager.SfxPlay(UISoundManager.Sfx.click);
        if(!uISoundManager.bgmPlayer.isPlaying)
        {
            uISoundManager.bgmPlayer.Play();
        }
    }
    public void clickOFF()
    {
        Debug.Log("BGM OFF");
        GlobalSoundManager.isBgmSound=false;
        uISoundManager.SfxPlay(UISoundManager.Sfx.click);
        uISoundManager.bgmPlayer.Stop();
    }

    public void clickEffectOn()
    {
        Debug.Log("효과음 ON");
    }

    public void clickEffectOff()
    {
        Debug.Log("효과음 OFF");
    }
}
