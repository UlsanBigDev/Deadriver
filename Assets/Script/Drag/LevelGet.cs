using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGet : MonoBehaviour
{
    public void SelectLevel(int level)
    {
        PlayerPrefs.SetInt("GameLevel", (int)level);
        Debug.Log("화면 전환됨");
        SceneManager.LoadScene("asy_develop");
    }

}
