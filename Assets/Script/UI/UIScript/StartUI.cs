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
    LoadingAnimation loadingAnimation;

    void Awake()
    {
        loadingAnimation = new LoadingAnimation();
        uISoundManager = FindObjectOfType<UISoundManager>();
    }
    public void Clickconfiguration()
    {
        Debug.Log("환경설정 클릭");
        BGM.gameObject.SetActive(true);
        uISoundManager.SfxPlay(UISoundManager.Sfx.click);
    }

    public void ClickClose()
    {
        Debug.Log("환경설정 창 닫기");
        BGM.gameObject.SetActive(false);
        uISoundManager.SfxPlay(UISoundManager.Sfx.click);
    }

    public void ClickStart()
    {
        loadingAnimation.changeScene("StoryLine_Developer");
        Debug.Log("LoadingScene으로 전환");
        SceneManager.LoadScene("LoadingScene");
        uISoundManager.SfxPlay(UISoundManager.Sfx.click);
    }

    public void ClickBgmOn()
    {
        Debug.Log("Bgm ON");
        GlobalSoundManager.isBgmSound = true;
        uISoundManager.SfxPlay(UISoundManager.Sfx.click);
        if(!uISoundManager.bgmPlayer.isPlaying)
        {
            uISoundManager.bgmPlayer.Play();
        }
    }
    public void ClickBgmOff()
    {
        Debug.Log("BGM OFF");
        GlobalSoundManager.isBgmSound=false;
        uISoundManager.SfxPlay(UISoundManager.Sfx.click);
        uISoundManager.bgmPlayer.Stop();
    }

    public void ClickSfxOn()
    {
        Debug.Log("SFX ON");
        GlobalSoundManager.isSfxSound = true;
        uISoundManager.SfxPlay(UISoundManager.Sfx.click);
    }

    public void ClickSfxOff()
    {
        Debug.Log("SFX OFF");
        GlobalSoundManager.isSfxSound = false;
        uISoundManager.SfxPlay(UISoundManager.Sfx.click);
    }
}