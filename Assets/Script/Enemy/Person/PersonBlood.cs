using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonBlood : MonoBehaviour
{
    public Image Blood;

    public void ShowPersonBlood()
    {
        Blood.gameObject.SetActive(true);
    }
}

