using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonBlood : MonoBehaviour
{
    public Image PersonBloodPanel;

    public void ShowBlood()
    {
        Debug.Log(PersonBloodPanel);
        PersonBloodPanel.gameObject.SetActive(true);
    }
}
