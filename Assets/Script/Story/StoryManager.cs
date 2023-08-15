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
            new StoryNormal(
                new List<string>()
                {
                    "차를 사고 좋은 점이라 하면 여러 가지가 있겠지만.",
                    "역시 제일 좋은 점은 30분 정도  더 자도 아슬아슬하다거나 지각한다거나 하지 않는다는 점일듯 하다.",
                    "날씨가 좋다.. 출근을 하는 내 맘을 몰라주듯"
                },
                new StorySelect(
                    new List<string>()
                    {
                        "(전화가 울린다) Ring Ring Ring (고등학교 친구 장민광)",
                        "나 : 여보세요?",
                        "민광 : 야! 고기 안먹을 이유좀! ",
                        "나 : 너 어제 인스타 보니까 어제 고기 먹었던것 같은데 괜찮은거야???",
                        "민광 : 놈!!!!!!!!!!!!!!!!!",
                        "민광 : 그거는 고기를 안먹을 이유가 안돼! 고기나 먹으러가자 ㄱㄱ!!"
                    },
                    (
                        new StoryTitle("친구를 만난다", 1100),
                        new StoryTitle("친구를 안만난다", 1200)
                    )
                )
            )
        );
        /*storyMap.Add(1100); // 고등학교 친구를 만나는 이벤트*/        
        /*storyMap.Add(1200); // 고등학교 친구 약속 거절 이벤트*/
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
            if (current.isLast) {
                if (current is StorySelect) {
                    /*Debug.Log("선택지 출력...");*/
                    storyChatUI.PrintStorySelectButton(current as StorySelect);
                    return;
                }
            }
            return;
        } else {            
            if (current is StoryNormal) {
                StoryNormal sn = current as StoryNormal;
                SetCurrentStory(sn.next);
                return;
            }
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
