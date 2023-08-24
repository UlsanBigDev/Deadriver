using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveSceneSoundManager : MonoBehaviour
{
    public AudioSource bgmPlayer;
    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip;
    public enum Sfx { click, crashBuiling, crashPersonWomen, crashCar, over, pressAccel, drivingNormal};
    int sfxCursor;
    void Start()
    {
        if (GlobalSoundManager.isBgmSound)
        {
            bgmPlayer.Play();
            Debug.Log("브금ON");
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
}
