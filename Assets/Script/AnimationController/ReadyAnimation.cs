using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyAnimation : MonoBehaviour
{
    [SerializeField]
    Image fadeIn;

    private void Start()
    {
        fadeIn.transform.SetAsLastSibling();
    }
}
