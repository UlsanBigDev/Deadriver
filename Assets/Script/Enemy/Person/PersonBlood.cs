using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonBlood : MonoBehaviour
{
    public static Image PersonBloodPanel;

    public static void ShowBlood()
    {
        Debug.Log(PersonBloodPanel);
        PersonBloodPanel.gameObject.SetActive(true);
    }
}
