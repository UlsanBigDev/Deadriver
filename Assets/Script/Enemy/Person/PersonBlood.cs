using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonBlood : MonoBehaviour
{
    public GameObject PersonBloodPanel;

    public void ShowBlood()
    {
        PersonBloodPanel.SetActive(true);
    }
}
