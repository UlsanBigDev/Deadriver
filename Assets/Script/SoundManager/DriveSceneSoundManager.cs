using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveSceneSoundManager : MonoBehaviour
{
    public AudioSource bgmPlayer;
    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip;
    public enum Sfx { click, crashBuiling, crashPersonWomen, crashCar, over, pressAccel, drivingNormal };
    int sfxCursor;
    public static bool driveSoundEnabled = true;
    void Start()
    {
        bgmPlayer.volume = GlobalSoundManager.bgmVolume;
        if (GlobalSoundManager.isBgmSound)
        {
            bgmPlayer.Play();
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
            case Sfx.over:
                sfxPlayer[sfxCursor].clip = sfxClip[4];
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
        Destroy(this.bgmPlayer);
        Destroy(sfxPlayer[sfxCursor]);
    }
}