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
        Debug.Log("브금ON");
    }
    public void SfxPlay(Sfx type)
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
