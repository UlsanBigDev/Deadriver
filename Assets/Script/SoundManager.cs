using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgmPlayer;
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
