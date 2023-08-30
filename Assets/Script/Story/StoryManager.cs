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
    public StoryLineSoundManager storyLineSoundManager;
    public static StoryManager instance;
    public Dictionary<int, Story> storyMap = new Dictionary<int, Story>();
    [SerializeField]
    StoryChatUI storyChatUI;
    static Story current;
    bool isChatting;

    GameObject imageGroup;


    private void Awake()
    {
        instance = this;
        isChatting = true;
        InitializeStoryData();
        InitializeVariable();
        imageGroup = GameObject.Find("ImageGroup");
    }

    private void InitializeVariable()
    {
        storyLineSoundManager = FindObjectOfType<StoryLineSoundManager>();
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
        if (ConfigManager.isSystemPanel) return;
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
                        // 민욱 여기에 휴대폰 알람소리
                        storyLineSoundManager.SfxPlay(StoryLineSoundManager.Sfx.messeage);
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
                }, () => {
                    LoadingManager.sceneName = "Mission";
                    SceneManager.LoadScene("LoadingScene");
                }
            )
        );

        // 고등학교 친구를 만나서 술 권유 이벤트 1
        storyMap.Add(11,
            new StorySelect(
                new List<StoryScript>()
                {
                    new StoryScript("안지욱 : 사장님 삼겹살 4인분에 소주 두병이요~"),
                    new StoryScript("나 : 뭐야 너는 차 안 끌고 왔어?"),
                    new StoryScript("안지욱 : 어 내일 주말이라 피시방에서 밤샘이나 할라고"),
                    new StoryScript("안지욱 : 니도 한잔 마셔야지", ()=>{
                        if (imageGroup != null)
                            imageGroup.transform.Find("alchorEventBottle").gameObject.SetActive(true);
                    } ),
                    new StoryScript("나 : 흐음...")
                },
                (
                    new StoryTitle("마신다", 12, false),
                    new StoryTitle("안마신다", 13, false)
                )
            )
        );

        storyMap.Add(12,
            new Story(
                new List<StoryScript>()
                {
                    new StoryScript("나 : 안 마실 이유가 없지 함 줘봐라"),
                    new StoryScript("안지욱 : 역시 소광이 아주 상남자여", ()=>{
                        if (imageGroup != null) imageGroup.transform.Find("alchorEventHand").gameObject.SetActive(true);
                    } ),
                }, () => {
                    SetCurrentStory(storyMap[111]);
                }
            )
        );

        storyMap.Add(13,
            new Story(
                new List<StoryScript>()
                {
                    new StoryScript("나 : 흐음 별로 안 땡기는걸 니 혼자 마셔라"),
                    new StoryScript("안지욱 : 삼겹살에는 소주인데 이걸 참아?"),
                }, () => {
                    SetCurrentStory(storyMap[111]);
                }
            )
        );

        storyMap.Add(111,
            new StorySelect(
                new List<StoryScript>()
                {
                    new StoryScript("안지욱 : 자 내일 주말 이니까 한잔 받아라"),
                    new StoryScript("나 : 흐음.... 이게 맞는 짓인가", ()=>{
                    if (imageGroup != null) imageGroup.transform.Find("alchorEventHand").gameObject.SetActive(false);
                    } )
                },
                (
                    new StoryTitle("마신다", 112, false),
                    new StoryTitle("안마신다", 113, false)
                )
            )
        );

        storyMap.Add(112,
            new Story(
                new List<StoryScript>()
                {
                    new StoryScript("안지욱 : 야야 소광아 팔 떨어지겠다 빨리 받아라 ㅋㅋㅋ"),
                    new StoryScript("나 : 그래 어디 함 따라 봐바라 얼마나 잘 따르는지 보자"),
                },
                () =>
                {
                    SetCurrentStory(storyMap[1111]);
                }
            )
        );
        storyMap.Add(113,
            new Story(
                new List<StoryScript>()
                {
                    new StoryScript("나 : 됐다 별로 마시고 싶지 않네 니 다 마셔라 "),
                    new StoryScript("안지욱 : 아글나? 와글노? 마실라면 언제든 말해라"),

                },
                () =>
                {
                    SetCurrentStory(storyMap[1111]);
                }
            )
        );

        // 고등학교 친구를 만나서 술 권유 이벤트 3
        storyMap.Add(1111,
            new StorySelect(
                new List<StoryScript>()
                {
                    new StoryScript("안지욱 : 너 뭐 딴거는 안먹냐", ()=>{
                        if (imageGroup != null) imageGroup.transform.Find("alchorEventBottle").gameObject.SetActive(false);
                    }),
                    new StoryScript("나 : 딱히? 별로 생각 없는데?"),
                    new StoryScript("안지욱 : 그래? 그럼 이것만 마시고 드가자~~~", ()=>{
                        if (imageGroup != null) imageGroup.transform.Find("alchorEventBottle").gameObject.SetActive(true);
                    } ),
                },
                (
                    new StoryTitle("마신다", 1112, false),
                    new StoryTitle("안마신다", 1113, false)
                )
            )
        );

        storyMap.Add(1112,
            new Story(
                new List<StoryScript>()
                {
                    new StoryScript("나 : 자~~ 드가자~", () => {
                        if (imageGroup != null) imageGroup.transform.Find("alchorEventHand").gameObject.SetActive(true);
                    } ),
                    new StoryScript("안지욱 : 위하여~~"),
                    new StoryScript("나 : 위하여~~"),
                },
                () =>
                {
                    ChangeStoryById(3);
                }
            )
        );

        storyMap.Add(1113,
            new Story(
                new List<StoryScript>()
                {
                    new StoryScript("나 : 나는 여기까지 할란다"),
                    new StoryScript("안지욱 : 뭐야 재미없구로"),
                    new StoryScript("나 : 다음에는 재밌게 놀아 줄게"),
                    new StoryScript("안지욱 : 그래 다음에는 꼭이다"),
                },
                () =>
                {
                    ChangeStoryById(3);
                }
            )
        );
        storyMap.Add(3,
            new Story(
                new List<StoryScript>()
                {
                    new StoryScript("나 : 기사님 동구에 화정동으로 가주세요"),
                    new StoryScript("안지욱 : 으어어어억 아우야 내 먼저 들어가마"),
                    new StoryScript("나 : ㅋㅋ 취한거 봐라 꼭 살아서 집들어가라~"),
                    new StoryScript("나 : 그럼 슬슬 나도 집으로 들어가볼까"),
                }, () =>
                {
                    LoadingManager.sceneName = "Mission";
                    SceneManager.LoadScene("LoadingScene");
                }  
            )
        );
    }
}
