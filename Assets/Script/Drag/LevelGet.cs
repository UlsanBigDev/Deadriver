using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGet : MonoBehaviour
{
    public void SelectLevel(int level)
    {
        PlayerPrefs.SetInt("GameLevel", (int)level);
        Debug.Log("ȭ�� ��ȯ��");
        SceneManager.LoadScene("asy_develop");
    }

}
