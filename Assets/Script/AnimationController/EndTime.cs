using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTime : MonoBehaviour
{
    public void EndAnimation()
    {
        Debug.Log("애니메이션 끝");
        Time.timeScale = 0;
    }
}
