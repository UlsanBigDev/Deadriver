using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgmPlayer;
    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip;
    public enum Sfx { click, crashBuiling, crashBots, over };
    int sfxCursor;
    void Start()
    {
        bgmPlayer.Play();
        Debug.Log("브금ON");
    }
    public void SfxPlay(Sfx type)
    {
        switch (type)
        {
            case Sfx.click:
                sfxPlayer[sfxCursor].clip = sfxClip[Random.Range(0, 3)];
                break;
            case Sfx.crashBots:
                sfxPlayer[sfxCursor].clip = sfxClip[16];
                break;
            case Sfx.crashBuiling:
                sfxPlayer[sfxCursor].clip = sfxClip[41];
                break;
            case Sfx.over:
                sfxPlayer[sfxCursor].clip = sfxClip[32];
                break;
        }
        sfxPlayer[sfxCursor].Play();
        sfxCursor = (sfxCursor + 1) % sfxPlayer.Length;
    }
}
