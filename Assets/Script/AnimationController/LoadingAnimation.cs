using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingAnimation : MonoBehaviour
{
    Animator anim;
    public GameObject Loading;

    void Awake()
    {
        anim = Loading.GetComponent<Animator>();
    }

    public void change()
    {
        StartCoroutine(SceneChange());
    }

    public IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(1.5f);
        Debug.Log("씬 전환");
        SceneManager.LoadScene("UI");
    }
}
