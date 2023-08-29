using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public interface StartListener
{
    public void OnStart();
}

public interface UpdateListener
{
    public void OnUpdate();
}

public class GameManager : MonoBehaviour
{
    public static float personSpawnCoolTime = 5f;
    public static float enemyCarSpawnCoolTime = 10f;
    private static List<StartListener> startListeners = new List<StartListener>();
    public static void AddStartListener(StartListener listener)
    {
        startListeners.Add(listener);
    }

    private static List<UpdateListener> updateListeners = new List<UpdateListener>();

    public static void AddUpdateListener(UpdateListener listener)
    {
        updateListeners.Add(listener);
    }

    Player player;

    public Image panel;
    public GameObject drag;

    public AudioSource bgmPlayer;
    public SoundManager soundManager;

    [SerializeField]
    GameObject finishBoard;

    private static Animator finishBoardAnimator;

    private static GameObject _finishBoard;

    [SerializeField]
    private Image sightPanel;

    public Text missionText, timeText, crashText;
    public List<Mission> missions = Player.missionList;
    int i;
    

    private void Awake() //디버프를 drunkEvents 리스트에 추가(Add)해줌
    {
        _finishBoard = finishBoard;
        finishBoardAnimator = finishBoard.GetComponent<Animator>();
        /// 디버프 테스트 코드
        Car.AddDrunkEvent(new ManyEnemy());
        Car.AddDrunkEvent(new SightEvent(sightPanel));
        /// 
        /// 기타 상황 맞게 초기화 하는 구간
        if (Car.isSight)
        {
            sightPanel.gameObject.SetActive(true);
        }
        ///


        // PTK Missiion 기능 테스트 코드
        // startListeners = new List<StartListener>();
        // updateListeners = new List<UpdateListener>();
        // Player.missionList.Add(new TimeMission(10f)); // 제한시간 미션 10초 미션 생성 
        // Player.missionList.Add(new CrashMission(3)); // 제한 빌딩, 사람, 자동차 상관없이 충돌 미션 3회 미만 미션 생성
        // Player.missionList.Add(new CrashMission(3, CrashType.BUILDING)); // 제한 빌딩 충돌 미션 3회 미만 미션 생성

        //List<Mission> mission1List = mission1.missionList;
        //foreach(Mission mis in mission1List)
        //{
        //    if(mis is TimeMission)
        //    {

        //    }else if(mis is Crah)
        //}

        //Player.missionList.Add(new GroupMission(new List<Mission>() { new TimeMission(120f), new CrashMission(3) }, "어머니 급 가정방문"));
        //Player.missionList.Add(new GroupMission(new List<Mission>() { new TimeMission(240f), new CrashMission(6) }, "5분 내로 오면 5만원"));
        //Player.missionList.Add(new GroupMission(new List<Mission>() { new TimeMission(300f), new CrashMission(9) }, "상사 호출"));


        //Mission mission1 = new TimeMission(10f);
        //TimeMission timeMission = (TimeMission) mission1;
        //Debug.Log(timeMission.originTime);
        /*
        missionText.text = Player.missionList[0].title;

        foreach (Mission mis in misssion1List)
        {
            if (mis is TimeMission)
            {
                TimeMission timeMission = (TimeMission)mis;
                timeText.text = "제한 시간 : " + (timeMission.originTime/60) + "분";
            }
            else if (mis is CrashMission)
            {
                CrashMission crashMission = (CrashMission)mis;
                crashText.text = "충돌 제한 횟수 : " + crashMission.originCount + "번";
            }
        }*/

        Mission selectMission;
        if (Player.missionList.Count == 0)
            selectMission = new GroupMission(new List<Mission>() { new TimeMission(120f), new CrashMission(3) }, "어머니 급 가정방문");
        else
            selectMission = Player.missionList[0];
        missionText.text = selectMission.title;
        if (selectMission is GroupMission)
        {
            GroupMission groupMission = selectMission as GroupMission;
            foreach (Mission mission in groupMission.missionList)
            {
                if (mission is TimeMission)
                {
                    TimeMission timeMission = (TimeMission) mission;
                    timeText.text = "제한 시간 : " + (timeMission.originTime / 60) + "분";
                }
                else if (mission is CrashMission)
                {
                    CrashMission crashMission = (CrashMission) mission;
                    crashText.text = "충돌 제한 횟수 : " + crashMission.originCount + "번";
                }
            }
        }


    }

    private void Start()
    {
        foreach (StartListener listener in startListeners)
        {
            listener.OnStart();
        }
    }

    private void Update()
    {
        foreach (UpdateListener listener in updateListeners)
        {
            listener.OnUpdate();
        }
            
    }

    public static void GameEnd()
    {
        int count = 0;
        foreach (Mission mission in Player.missionList)
        {
            if (mission.GetState()) count++;
        }

        Debug.Log("성공한 미션 갯수 " + count);
        finishBoardAnimator.SetBool("Result", true);
        Debug.Log("결과창 출력!");
        DriveSceneSoundManager.driveSoundEnabled = false;
        Debug.Log("driveSoundEnabled = false in GameManager");
        if (finishBoardAnimator.GetCurrentAnimatorStateInfo(0).IsName("Result") && finishBoardAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime == 1f)
        {
            Debug.Log("애니메이션 끝");
            //Time.timeScale = 0;
        }
    }
    public static void GamePause()
    {
        Time.timeScale = 0;
    }

    public static void GameResume()
    {
        Time.timeScale = 1;
    }

}