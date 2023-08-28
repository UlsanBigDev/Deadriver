using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public static string sceneName;

    void Start()
    {
        StartCoroutine(LoadingCoroutine());
    }
    private IEnumerator LoadingCoroutine()
    {
        yield return new WaitForSecondsRealtime(6f);
        SceneManager.LoadScene(sceneName);
    }
}
