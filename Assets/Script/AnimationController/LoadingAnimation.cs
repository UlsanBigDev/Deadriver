using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingAnimation : MonoBehaviour
{
    public string change;

    public void changeScene(string changenext)
    {
        Debug.Log(changenext);
        change = changenext;
        SceneManager.LoadScene(change);
    }
}
