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
        Debug.Log("환경설정 클릭");
        BGM.gameObject.SetActive(true);
        driveSceneSoundManager.SfxPlay(DriveSceneSoundManager.Sfx.click);
    }

    public void ClickClose()
    {
        Debug.Log("환경설정 창 닫기");
        BGM.gameObject.SetActive(false);
        driveSceneSoundManager.SfxPlay(DriveSceneSoundManager.Sfx.click);
    }

    public void ClickBgmOn()
    {
        Debug.Log("Bgm ON");
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
        Debug.Log("BGM OFF");
        GlobalSoundManager.isBgmSound = false;
        driveSceneSoundManager.SfxPlay(DriveSceneSoundManager.Sfx.click);
        driveSceneSoundManager.bgmPlayerGreen.Stop();
        driveSceneSoundManager.bgmPlayerYellow.Stop();
        driveSceneSoundManager.bgmPlayerOrange.Stop();
        driveSceneSoundManager.bgmPlayerRed.Stop();
    }

    public void ClickSfxOn()
    {
        Debug.Log("SFX ON");
        GlobalSoundManager.isSfxSound = true;
        driveSceneSoundManager.SfxPlay(DriveSceneSoundManager.Sfx.click);
    }

    public void ClickSfxOff()
    {
        Debug.Log("SFX OFF");
        GlobalSoundManager.isSfxSound = false;
        driveSceneSoundManager.SfxPlay(DriveSceneSoundManager.Sfx.click);
    }
}