using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public static string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(LoadingManager.sceneName);
    }
}
