using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class StoryChat
{
    [SerializeField]
    TMP_Text storyChatText;

    public void PrintStoryChatText(string message)
    {
        storyChatText.text = message;
    }
}
