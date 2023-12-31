using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundManager : MonoBehaviour
{
    public AudioSource bgmPlayer;
    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip;
    public enum Sfx { click };
    int sfxCursor;
    void Start()
    {
        bgmPlayer.Play();
        Debug.Log("BGM-BellBass-ON");
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