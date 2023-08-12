using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager instance;
    static Dictionary<int, Story> storyMap = new Dictionary<int, Story>();

    [SerializeField]
    StoryChatUI storyChatUI;

    static Story current;

    bool isChatting;

    Player player;

    private void Awake()
    {
        instance = this;
        isChatting = true;
        // storyList.Add(new Story(0, new List<string>(){"aaa", "bbb"})); // 데이터 임시 하드코딩
        storyMap.Add(0, new StorySelect(new List<string>() { "안녕하세요 어쩌구입니다 ", "HI", "BY", "그래서 술 마심 "}, (new StoryTitle("ONE", 1), new StoryTitle("TWO", 2))));
        storyMap.Add(1, new StorySelect(new List<string>() { "'휴 어쩌' 어쩌구입니다 ", "HI", "BY", "그래서 술 마심 " }, (new StoryTitle("마신다", 1), new StoryTitle("마신다", 2))));
        storyMap.Add(2, new StorySelect(new List<string>() { "ssss", "asasa", "asdsadas", "FFFF" }, (new StoryTitle("마신다", 1), new StoryTitle("마신다", 2))));
        player = Player.GetPlayer();
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
        if (current != null) current.Reset();
        current = story;
        storyChatUI.PrintStoryChatText(current.Now());
    }

    public void ChangeStory(int id)
    {
        SetCurrentStory(storyMap[id]);
    }
}
