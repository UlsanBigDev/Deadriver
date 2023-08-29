using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DriveUI : MonoBehaviour
{
    public void ChangeLoading()
    {
        DriveSceneSoundManager.driveSfxSoundEnabled = false;
        Time.timeScale = 1;
        LoadingManager.sceneName = "StartScene";
        SceneManager.LoadScene("LoadingScene");
    }
}
