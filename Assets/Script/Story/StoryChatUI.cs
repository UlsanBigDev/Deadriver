using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class StoryChatUI
{
    [SerializeField]
    TMP_Text storyChatText;

    [SerializeField]
    Button storyButton1;

    [SerializeField]
    TMP_Text storyButtonText1;

    [SerializeField]
    Button storyButton2;

    [SerializeField]
    TMP_Text storyButtonText2;

    public void PrintStoryChatText(string message)
    {
        storyChatText.text = message;
    }

    public void PrintStorySelectButton(StorySelect storySelect)
    {
        storyButtonText1.text = storySelect.s1.title;
        storyButtonText2.text = storySelect.s2.title;
    }
}
    