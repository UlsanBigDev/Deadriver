using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    //static List<Story> storyList = new List<Story>();
    static Dictionary<int, Story> storyMap = new Dictionary<int, Story>();

    [SerializeField]
    StoryChatUI storyChatUI;

    Story current;

    bool isChatting;

    private void Awake()
    {
        isChatting = true;
        // storyList.Add(new Story(0, new List<string>(){"aaa", "bbb"})); // 데이터 임시 하드코딩
        storyMap.Add(0, new StorySelect(new List<string>() { "안녕하세요 어쩌구입니다 ", "HI", "BY", "그래서 술 마심 "}, (new StoryTitle("마신다", 1), new StoryTitle("마신다", 2))));
        storyMap.Add(1, new StorySelect(new List<string>() { "'휴 어쩌' 어쩌구입니다 ", "HI", "BY", "그래서 술 마심 " }, (new StoryTitle("마신다", 1), new StoryTitle("마신다", 2))));
        storyMap.Add(2, new StorySelect(new List<string>() { "ssss", "asasa", "asdsadas", "FFFF" }, (new StoryTitle("마신다", 1), new StoryTitle("마신다", 2))));
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
            storyChatUI.PrintStoryChatText(current.Now());
            if (current.isLast && current is StorySelect) {
                Debug.Log("선택지 출력...");
                storyChatUI.PrintStorySelectButton(current as StorySelect);
                return;
            }
            return;
        }   

        
    }
    public void SetCurrentStory(Story story)
    {
        this.current = story;
        storyChatUI.PrintStoryChatText(current.Now());
    }
}
