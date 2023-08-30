using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfigManager : MonoBehaviour
{
    private static int WIDTH = 1920;
    private static int HEIGHT = 1080;
    [SerializeField]
    private GameObject systemPanel;
    [SerializeField]
    private GameObject soundSettingPanel;
    public static bool isSystemPanel;
    public static bool isSoundPanel;

    private void Awake()
    {
        InitScreen();
        InitializeVariable();        
    }
    private void InitScreen()
    {   
        Screen.SetResolution(WIDTH, HEIGHT, true);
    }

    private void InitializeVariable()
    {
        isSystemPanel = false;        
    }
    private void OnEnable()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) isSystemPanel = !isSystemPanel;
    }

    private void LateUpdate()
    {
        if (systemPanel) {
            if (isSystemPanel) OpenSystemPanel();
            else CloseSystemPanel();
        }
        
    }

    private void OpenSystemPanel()
    {
        GameManager.GamePause();
        systemPanel.SetActive(true);
    }

    private void CloseSystemPanel()
    {
        GameManager.GameResume();
        systemPanel.SetActive(false);
    }

    public void GameEnd()
    {
        Application.Quit();
    }

    public void OpenSoundPanel()
    {
        soundSettingPanel.SetActive(true);
    }

    public void CloseSoundPanel()
    {
        soundSettingPanel.SetActive(false);
    }

    public void ONBGM()
    {
        GlobalSoundManager.isBgmSound = true;
    }

    public void OFFBGM()
    {
        GlobalSoundManager.isBgmSound = false;
    }

    public void ONSFX()
    {
        GlobalSoundManager.isSfxSound = true;
    }

    public void OFFSFX()
    {
        GlobalSoundManager.isSfxSound = false;
    }

    public void SetBGMVolume(float value)
    {
        GlobalSoundManager.bgmVolume = value;
    }

    public void SetSFXVolume(float value)
    {
        GlobalSoundManager.sfxVolume = value;
    }

    public void ChangeSceneByTitle()
    {
        SceneManager.LoadScene("StartScene");
    }
}
