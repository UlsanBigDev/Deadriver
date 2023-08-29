using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveSceneSoundManager : MonoBehaviour
{
    public AudioSource bgmPlayerGreen;
    public AudioSource bgmPlayerYellow;
    public AudioSource bgmPlayerOrange;
    public AudioSource bgmPlayerRed;
    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip;
    public enum Sfx { click, crashBuiling, crashPersonWomen, crashCar, over, pressAccel};
    int sfxCursor;
    public static bool driveSoundEnabled = true;
    void Start()
    {
        bgmPlayerGreen.volume = GlobalSoundManager.bgmVolume;
        bgmPlayerYellow.volume = GlobalSoundManager.bgmVolume;
        bgmPlayerOrange.volume = GlobalSoundManager.bgmVolume;
        bgmPlayerRed.volume = GlobalSoundManager.bgmVolume;
        if (GlobalSoundManager.isBgmSound)
        {
            if (Player.GetPlayer().drunkLevel == DrunkLevel.GREEN)
            {
                bgmPlayerGreen.Play();
            }
            if (Player.GetPlayer().drunkLevel == DrunkLevel.YELLOW)
            {
                bgmPlayerYellow.Play();
            }
            if (Player.GetPlayer().drunkLevel == DrunkLevel.ORANGE)
            {
                bgmPlayerOrange.Play();
            }
            if (Player.GetPlayer().drunkLevel == DrunkLevel.RED)
            {
                bgmPlayerRed.Play();
            }
        }
    }
    public void SfxPlay(Sfx type)
    {
        switch (type)
        {
            case Sfx.crashBuiling:
                sfxPlayer[sfxCursor].clip = sfxClip[0];
                break;
            case Sfx.crashCar:
                sfxPlayer[sfxCursor].clip = sfxClip[1];
                break;
            case Sfx.crashPersonWomen:
                sfxPlayer[sfxCursor].clip = sfxClip[2];
                break;
            case Sfx.pressAccel:
                sfxPlayer[sfxCursor].clip = sfxClip[3];
                break;
            case Sfx.click:
                sfxPlayer[sfxCursor].clip = sfxClip[4];
                break;
            case Sfx.over:
                sfxPlayer[sfxCursor].clip = sfxClip[5];
                break;
        }
        sfxPlayer[sfxCursor].Play();
        sfxCursor = (sfxCursor + 1) % sfxPlayer.Length;
    }
    void Update()
    {
        if (driveSoundEnabled == false)
        {
            Debug.Log("사운드종료");
            DestroySounds();
        }
    }
    public void DestroySounds()
    {
        switch (Player.GetPlayer().drunkLevel)
        {
            case DrunkLevel.GREEN:
                Destroy(bgmPlayerGreen); break;
            case DrunkLevel.YELLOW:
                Destroy(bgmPlayerYellow); break;
            case DrunkLevel.ORANGE:
                Destroy(bgmPlayerOrange); break;
            case DrunkLevel.RED:
                Destroy(bgmPlayerRed); break;
        }
        Destroy(sfxPlayer[sfxCursor]);
    }
    public void SetBgmVolume(float bgmVolume)
    {
        GlobalSoundManager.bgmVolume = bgmVolume;
        bgmPlayerGreen.volume = bgmVolume;
        bgmPlayerYellow.volume = bgmVolume;
        bgmPlayerOrange.volume = bgmVolume;
        bgmPlayerRed.volume = bgmVolume;
    }
    public void SetSfxVolume(float sfxVolume)
    {
        GlobalSoundManager.sfxVolume = sfxVolume;
        foreach (var sfx in sfxPlayer)
        {
            sfx.volume = sfxVolume;
        }
    }
}