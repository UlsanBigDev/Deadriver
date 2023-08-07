using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    //static List<Story> storyList = new List<Story>();
    static Dictionary<int, Story> storyMap = new Dictionary<int, Story>();

    [SerializeField]
    StoryChat storyChat;

    Story current;

    bool isChatting;

    private void Awake()
    {
        isChatting = true;
        // storyList.Add(new Story(0, new List<string>(){"aaa", "bbb"})); // 데이터 임시 하드코딩
        storyMap.Add(0, new Story(new List<string>() { "aaa", "bbb" }));
    }
    private void Start()
    {
        //current = storyMap[0];
        SetCurrentStory(storyMap[0]);
    }
    private void Update()
    {
        if (isChatting) Reading();
    }
    private void Reading()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        if (!current.isLast) {
            storyChat.PrintStoryChatText(current.Now());
            return;
        }
    }
    public void SetCurrentStory(Story story)
    {
        this.current = story;
        storyChat.PrintStoryChatText(current.Now());
    }
}
