using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class StoryChatUI
{
    [SerializeField]
    StoryLineSoundManager storyLineSoundManager;

    [SerializeField]
    TMP_Text storyChatText;

    [SerializeField]
    GameObject storySelectPanel;

    [SerializeField]
    Button storyButton1;

    [SerializeField]
    TMP_Text storyButtonText1;

    [SerializeField]
    Button storyButton2;

    [SerializeField]
    TMP_Text storyButtonText2;

    [SerializeField]
    Image phoneBoard;

    [SerializeField]
    TMP_Text phoneBoardText;

    StoryTitle story1;
    StoryTitle story2;

    public void PrintPhoneText(string message)
    {
        phoneBoard.gameObject.SetActive(true);
        phoneBoardText.text = message;
    }

    public void ClosePhone()
    {
        phoneBoard.gameObject.SetActive(false);
    }

    public void PrintStoryChatText(string message)
    {
        storyChatText.text = message;
    }

    public void PrintStorySelectButton(StorySelect storySelect)
    {
        story1 = storySelect.s1;
        story2 = storySelect.s2;
        SetStoryButtonText();
        SetStoryButtonFunc();
        EnablePanel();
    }

    private void EnablePanel()
    {
        storySelectPanel.gameObject.SetActive(true);
    }

    private void DisablePannel()
    {
        storySelectPanel.gameObject.SetActive(false);
    }

    private void SetStoryButtonText()
    {
        storyButtonText1.text = story1.title;
        storyButtonText2.text = story2.title;
    }

    private void SetStoryButtonFunc()
    {
        storyButton1.onClick.RemoveAllListeners();
        storyButton2.onClick.RemoveAllListeners();

        storyButton1.onClick.AddListener(() => {
            SoundClick();
            if (story1.isSceneChange) StoryManager.ChangeStoryById(story1.id);
            else StoryManager.instance.ChangeStory(story1.id);
            DisablePannel();
        });
        storyButton2.onClick.AddListener(() => {
            SoundClick();
            if (story2.isSceneChange) StoryManager.ChangeStoryById(story2.id);
            else StoryManager.instance.ChangeStory(story2.id);
            DisablePannel();
        });
    }
    public void SoundClick()
    {
        storyLineSoundManager.SfxPlay(StoryLineSoundManager.Sfx.click);
    }

    

}