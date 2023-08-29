using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryLineSoundManager : MonoBehaviour
{
    public AudioSource bgmPlayer;
    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip;
    public enum Sfx { click, messeage };
    int sfxCursor;
    void Start()
    {
        bgmPlayer.volume = GlobalSoundManager.bgmVolume;
        if (GlobalSoundManager.isBgmSound)
        {
            bgmPlayer.Play();
            Debug.Log("BGM-Deadriver-ON");
        }
    }
    public void SfxPlay(Sfx type)
    {
        if (GlobalSoundManager.isSfxSound)
        {
            switch (type)
            {
                case Sfx.click:
                    sfxPlayer[sfxCursor].clip = sfxClip[0];
                    break;
                case Sfx.messeage:
                    sfxPlayer[sfxCursor].clip = sfxClip[1];
                    break;
            }
            sfxPlayer[sfxCursor].Play();
            sfxCursor = (sfxCursor + 1) % sfxPlayer.Length;
        }
    }
    public void SetBgmVolume(float bgmVolume)
    {
        GlobalSoundManager.bgmVolume = bgmVolume;
        bgmPlayer.volume = bgmVolume;
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
