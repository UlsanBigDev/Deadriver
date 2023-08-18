using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgmPlayer;
    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip;
    public enum Sfx { crash, };
    int sfxCursor;
    void Start()
    {
        bgmPlayer.Play();
        Debug.Log("브금ON");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
