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
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.9f)
            {
                /*yield return new WaitForSeconds(6f);*/
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }

    }
}
