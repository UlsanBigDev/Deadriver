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

    StoryTitle story1;
    StoryTitle story2;

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
            Debug.Log("선택지 클릭됨");
            SoundClick();
            StoryManager.instance.ChangeStory(story1.id);
            DisablePannel();
        });
        storyButton2.onClick.AddListener(() => {
            StoryManager.instance.ChangeStory(story2.id);
            DisablePannel();
        });
    }
    public void SoundClick()
    {
        storyLineSoundManager.SfxPlay(StoryLineSoundManager.Sfx.click); ////// 오류는 아닌데 콘솔에서 여기로 찝어줌 인스턴스 할당이 null 뭐시기 이해불가
    }
}