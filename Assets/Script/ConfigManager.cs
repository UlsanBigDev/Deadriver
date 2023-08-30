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
}
