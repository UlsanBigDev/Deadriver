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


    private void Awake()
    {
        instance = this;
        isChatting = true;
        InitializeStoryData();
    }

    private void InitializeStoryData()
    {
        /*
         * StorySelect(대화내용[], (다음 스토리 선택지1, 다음 스토리 선택지2), [callBack=없어도])
         */
        storyMap.Add(1000,
            new Story(
                new List<string>()
                {
                    "차를 사고 좋은 점이라 하면 여러 가지가 있겠지만.",
                    "역시 제일 좋은 점은 30분 정도  더 자도 아슬아슬하다거나 지각한다거나 하지 않는다는 점일듯 하다.",
                    "날씨가 좋다.. 출근을 하는 내 맘을 몰라주듯"
                }
            )
        );
        storyMap.Add(1,
            new StorySelect(
                new List<string>() { 
                    "'휴 어쩌' 어쩌구입니다 ",
                    "HI", "BY", "그래서 술 마심 "
                },
                (
                    new StoryTitle("마신다", 1),
                    new StoryTitle("마신다", 2)
                )
            )
        );        
    }

    private void Start()
    {
        SetCurrentStory(storyMap[1000]);
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
        current.Run();
        storyChatUI.PrintStoryChatText(current.Now());
    }

    public void ChangeStory(int id)
    {
        SetCurrentStory(storyMap[id]);
    }
}
