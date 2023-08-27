using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    public static StoryManager instance;
    static Dictionary<int, Story> storyMap = new Dictionary<int, Story>();
    [SerializeField]
    StoryChatUI storyChatUI;
    static Story current;
    bool isChatting;
    private int testValue = 0;


    private void Awake()
    {
        instance = this;
        isChatting = true;
        InitializeStoryData();
    }
    private void Test()
    {   
        Debug.Log(testValue++);
    }

    private void InitializeStoryData()
    {
        /*
         * StorySelect(대화내용[], (다음 스토리 선택지1, 다음 스토리 선택지2), [callBack=없어도됨])
         */
        storyMap.Add(1000,
            new StoryChain(
                new List<StoryScript>()
                {
                    new StoryScript("차를 사고 좋은 점이라 하면 여러 가지가 있겠지만.", Test),
                    new StoryScript("역시 제일 좋은 점은 30분 정도  더 자도 아슬아슬하다거나 지각한다거나 하지 않는다는 점일듯 하다.", Test),
                    new StoryScript("날씨가 좋다.. 출근을 하는 내 맘을 몰라주듯", Test)
                },
                new StorySelect(
                    new List<StoryScript>()
                    {
                        new StoryScript("(전화가 울린다) Ring Ring Ring (고등학교 친구 장민광)"),
                        new StoryScript("나 : 여보세요?"),
                        new StoryScript("민광 : 야! 고기 안먹을 이유좀! "),
                        new StoryScript("나 : 너 어제 인스타 보니까 어제 고기 먹었던것 같은데 괜찮은거야???"),
                        new StoryScript("민광 : 놈!!!!!!!!!!!!!!!!!"),
                        new StoryScript("민광 : 그거는 고기를 안먹을 이유가 안돼! 고기나 먹으러가자 ㄱㄱ!!")
                    },
                    (
                        new StoryTitle("친구를 만난다", 1100),
                        new StoryTitle("친구를 안만난다", 1200)
                    )
                )
            )
        );

        // 고등학교 친구를 만나서 밥 먹는 이벤트
        storyMap.Add(1100,
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
        );;
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
                    storyChatUI.PrintStorySelectButton(current as StorySelect);
                    return;
                } else if (current is StoryChain) {
                    StoryChain sn = current as StoryChain;
                    SetCurrentStory(sn.next);
                    return;
                }
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
}
