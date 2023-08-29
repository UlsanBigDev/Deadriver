using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{   
    private void Awake()
    {
        int width = 1920;
        int height = 1080;
        Screen.SetResolution(width, height, true);
        DontDestroyOnLoad(this);
    }
}
