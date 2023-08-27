using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    private static int nextStoryId;
    public static void ChangeStoryById(int id)
    {
        nextStoryId = id;
        SceneManager.LoadScene("Story" + id);

    }
    public static StoryManager instance;
    public Dictionary<int, Story> storyMap = new Dictionary<int, Story>();
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

    private void Start()
    {
        SetCurrentStory(storyMap[nextStoryId]);
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
                    storyChatUI.PrintStorySelectButton(current as StorySelect);
                    return;
                } else if (current is StoryChain) {
                    StoryChain sn = current as StoryChain;
                    SetCurrentStory(sn.next);
                    return;
                }
            }
            return;
        } else {
            current.Run();
        }

        
    }
    public void SetCurrentStory(Story story)
    {
        if (current != null) current.Reset();
        current = story;
        //current.Run();
        storyChatUI.PrintStoryChatText(current.Now());
    }

    public void ChangeStory(int id)
    {
        try
        {
            SetCurrentStory(storyMap[id]);
        }
        catch(System.Exception e)
        {

            SetCurrentStory(
                new Story(
                    new List<StoryScript>() {
                        new StoryScript("미구현 드라이브 미션으로 이동합니다"),
                        new StoryScript("", () => {
                            Player player = Player.GetPlayer();
                            player.SetDrunkGauge(player.drunkGauge + 0);
                            LoadingManager.sceneName = "Drive";
                            SceneManager.LoadScene("LoadingScene");
                        })
                    }
                )   
            );
        }
    }

    private void InitializeStoryData()
    {
        /*
         * StorySelect(대화내용[], (다음 스토리 선택지1, 다음 스토리 선택지2), [callBack=없어도됨])
         */
        storyMap.Add(0,
            new Story(
                new List<StoryScript>()
                {
                    new StoryScript("차를 사고 좋은 점이라 하면 여러 가지가 있겠지만."),
                    new StoryScript("역시 제일 좋은 점은 30분 정도  더 자도 아슬아슬하다거나 지각한다거나 하지 않는다는 점일듯 하다."),
                    new StoryScript("날씨가 좋다.. 출근을 하는 내 맘을 몰라주듯")
                },
                () => {
                    ChangeStoryById(1);
                }
            )
        );
        storyMap.Add(1,
            new StorySelect(
                new List<StoryScript>()
                {
                    new StoryScript("오늘도 열심히 하자!"),
                    new StoryScript("(대충 전화 울리는 소리)", ()=>{
                        Debug.Log("대충 문자 알람 소리");
                    }),
                    new StoryScript("", ()=>{
                        storyChatUI.PrintPhoneText("[안지욱] 야 오늘 삼겹살 먹을꺼니까 군말 없이 튀어나와라 불만없제?");
                    }),
                    new StoryScript("(고등학교 동창 친구 에게서 밥을 먹자는 내용 이다)", ()=>{
                        storyChatUI.ClosePhone();
                    }),
                    new StoryScript("흐음 오랜만에 같이 밥이나 먹어줄까 흠..."),
                },
                (
                    new StoryTitle("수락한다", 11),
                    new StoryTitle("거절한다", 2, false)
                )
            )
        );
        // 고등학교 친구를 약속 거절 이벤트
        storyMap.Add(2,
            new Story(
                new List<StoryScript>()
                {
                    new StoryScript("(음 오늘은 별로 가고 싶지 않은걸? 거절 해야겠다.)")
                }
            )
        );

        // 고등학교 친구를 만나서 밥 먹는 이벤트
        storyMap.Add(11,
            new StorySelect(
                new List<StoryScript>()
                {
                    new StoryScript("민광 : 사장님 삼겹살 4인분에 소주 두병이요~"),
                    new StoryScript("나 : 나는 차몰고 와서 소주는 못 마실것 같은데 콜라나 마실게"),
                    new StoryScript("민광 : 에헤이~ 뭔 콜라여 쪼~끔만 마시자 쬐끔만"),
                    new StoryScript("민광 : 어차피 이 동네 단속도 잘 안떠~"),
                    new StoryScript("나 : 쓰읍 단속이 문제가 아닌데...")
                },
                (
                    new StoryTitle("마신다", 1110),
                    new StoryTitle("안마신다", 1120)
                )
            )
        );

        // 고등학교 친구를 만나서 술까지 마시는 이벤트 - 1
        storyMap.Add(1110,
            new Story(
                new List<StoryScript>()
                {
                    new StoryScript("(알딸딸한게 취기가 올라온다)"),
                    new StoryScript("민광 : 야 재미있었다~ 내일 보자~"),
                    new StoryScript("나 : 어~ 그래 잘들어가고 언젠가 보자"),
                    new StoryScript("하아.. 별로 안 취한것 같은데 운전이나 해야겠다")
                },
                () => {
                    Player player = Player.GetPlayer();
                    player.SetDrunkGauge(player.drunkGauge + 70);
                    LoadingManager.sceneName = "Drive";
                    SceneManager.LoadScene("LoadingScene");
                }
            )
        );

        // 최소 문자열 스크립트가 두줄 이여야함
        // 고등학교 친구를 만나서 술 거절 이벤트 - 1
        storyMap.Add(1120,
            new StorySelect(
                new List<StoryScript>()
                {
                    new StoryScript("진짜 안마실 꺼야?"),
                    new StoryScript("나 삐진다?")
                },
                (
                    new StoryTitle("마신다", 1110),
                    new StoryTitle("안마신다", 1130)
                )
            )
        ); ;
    }
}
