using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundSetting : MonoBehaviour
{
    public Button configuration;
    public Image BGM;
    public DriveSceneSoundManager driveSceneSoundManager;
    public AudioSource bgmPlayer;

    void Awake()
    {
        driveSceneSoundManager = FindObjectOfType<DriveSceneSoundManager>();
    }
    public void Clickconfiguration()
    {
        Debug.Log("소리설정 클릭");
        BGM.gameObject.SetActive(true);
        driveSceneSoundManager.SfxPlay(DriveSceneSoundManager.Sfx.click);
    }

    public void ClickClose()
    {
        Debug.Log("소리설정 닫기"); 
        BGM.gameObject.SetActive(false);
        driveSceneSoundManager.SfxPlay(DriveSceneSoundManager.Sfx.click);
    }

    public void ClickBgmOn()
    {
        Debug.Log("소리설정 브금 ON");
        GlobalSoundManager.isBgmSound = true;
        driveSceneSoundManager.SfxPlay(DriveSceneSoundManager.Sfx.click);
        if (!driveSceneSoundManager.bgmPlayerGreen.isPlaying && Player.GetPlayer().drunkLevel == DrunkLevel.GREEN)
        {
            driveSceneSoundManager.bgmPlayerGreen.Play();
        }
        if (!driveSceneSoundManager.bgmPlayerYellow.isPlaying && Player.GetPlayer().drunkLevel == DrunkLevel.YELLOW)
        {
            driveSceneSoundManager.bgmPlayerYellow.Play();
        }
        if (!driveSceneSoundManager.bgmPlayerOrange.isPlaying && Player.GetPlayer().drunkLevel == DrunkLevel.ORANGE)
        {
            driveSceneSoundManager.bgmPlayerOrange.Play();
        }
        if (!driveSceneSoundManager.bgmPlayerRed.isPlaying && Player.GetPlayer().drunkLevel == DrunkLevel.RED)
        {
            driveSceneSoundManager.bgmPlayerRed.Play();
        }
    }
    public void ClickBgmOff()
    {
        Debug.Log("소리설정 브금 OFF");
        GlobalSoundManager.isBgmSound = false;
        driveSceneSoundManager.SfxPlay(DriveSceneSoundManager.Sfx.click);
        driveSceneSoundManager.bgmPlayerGreen.Stop();
        driveSceneSoundManager.bgmPlayerYellow.Stop();
        driveSceneSoundManager.bgmPlayerOrange.Stop();
        driveSceneSoundManager.bgmPlayerRed.Stop();
    }

    public void ClickSfxOn()
    {
        Debug.Log("소리설정 효과음 ON");
        GlobalSoundManager.isSfxSound = true;
        Debug.Log("소리설정 ON 딸깍");
        driveSceneSoundManager.SfxPlay(DriveSceneSoundManager.Sfx.click);
    }

    public void ClickSfxOff()
    {
        Debug.Log("소리설정 효과음  OFF");
        GlobalSoundManager.isSfxSound = false;
        Debug.Log("소리설정 OFF 딸깍");
        driveSceneSoundManager.SfxPlay(DriveSceneSoundManager.Sfx.click);
    }
}