using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DriveUI : MonoBehaviour
{
    public void ChangeLoading()
    {
        SceneManager.LoadScene("LoadingScene");
    }
}
