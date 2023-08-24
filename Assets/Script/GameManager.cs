using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
    
    private static List<StartListener> startListeners;
    public static void AddStartListener(StartListener listener)
    {
        startListeners.Add(listener);
    }
    private static List<UpdateListener> updateListeners;
    public static void AddUpdateListener(UpdateListener listener)
    {
        updateListeners.Add(listener);
    }


    public Transform[] GreenArray;
    public Transform[] YELLOWArray;
    public Transform[] ORANGEArray;
    public Transform[] REDArray;

    Player player;
    ObstacleEvent obstacleEvent;
    SightEvent sightEvent;


    public Image panel;
    public GameObject drag;

    public AudioSource bgmPlayer;
    public SoundManager soundManager;

    public int i = 613;

    [SerializeField]
    GameObject finishBoard;

    
    private static Animator finishBoardAnimator;

    private static GameObject _finishBoard;


    private void Awake() //디버프를 drunkEvents 리스트에 추가(Add)해줌
    {
        _finishBoard = finishBoard;
        finishBoardAnimator = finishBoard.GetComponent<Animator>();
        //난이도 받아옴
        DrunkLevel level = Player.GetPlayer().drunkLevel;
        //Start로 하면 AbstractCar 스크립트에서의 Start에서 foreach문으로 리스트의 Run을 호출하는거랑
        //여기서 Add하는 거랑 동시에 일어나기 때문에 Add를 먼저 해준 후에 리스트의 Run들을 호출해야하니까 여기는 Awake로
        /* Awake( 리스트에 Add ) -> Start( 리스트에 Add 된 값들에 해당하는 Run을 실행 ) */

        //Car.AddDrunkEvent(new RashEvent());
        //Car.AddDrunkEvent(new RotationEvent());
        //Car.AddDrunkEvent(new ControlEvent()); 
        //Debug.Log(panel);
        //Car.AddDrunkEvent(new SightEvent(panel));
        //sightEvent = new SightEvent(panel);

        /* 장애물 생성 코드*/
        //난이도마다 배열을 만들고 그 배열에 객체를 넣고 그 객체를 넘겨줌
        if (level == DrunkLevel.GREEN)
        {
            ObstacleEvent obstacleEvent = new ObstacleEvent(GreenArray, drag);
            Car.AddDrunkEvent(obstacleEvent);
            this.obstacleEvent = obstacleEvent;
            //obstacleEvent = new ObstacleEvent(GreenArray, drag);
            //drag Object를 ObstacleEvent에서 지정해주는 게 아니라 여기서 drag Object를 지정해주고 전달해야함
            //ObstacleEvent에서 지정하니까 초기화가 되는 듯?
        }
        else if (level == DrunkLevel.YELLOW)
        {
            ObstacleEvent obstacleEvent = new ObstacleEvent(YELLOWArray, drag);
            Car.AddDrunkEvent(obstacleEvent);
            this.obstacleEvent = obstacleEvent;
        }
        else if (level == DrunkLevel.ORANGE)
        {
            ObstacleEvent obstacleEvent = new ObstacleEvent(ORANGEArray, drag);
            Car.AddDrunkEvent(obstacleEvent);
            this.obstacleEvent = obstacleEvent;
        }
        else if (level == DrunkLevel.RED)
        {
            ObstacleEvent obstacleEvent = new ObstacleEvent(REDArray, drag);
            Car.AddDrunkEvent(obstacleEvent);
            this.obstacleEvent = obstacleEvent;
        }
        // PTK Missiion 기능 테스트 코드
        startListeners = new List<StartListener>();
        updateListeners = new List<UpdateListener>();
        // Player.missionList.Add(new TimeMission(10f)); // 제한시간 미션 10초 미션 생성 
        // Player.missionList.Add(new CrashMission(3)); // 제한 빌딩, 사람, 자동차 상관없이 충돌 미션 3회 미만 미션 생성
        // Player.missionList.Add(new CrashMission(3, CrashType.BUILDING)); // 제한 빌딩 충돌 미션 3회 미만 미션 생성
        Player.missionList.Add(new GroupMission(new List<Mission>() { new TimeMission(60f), new CrashMission(3) }));
        ///
    }

    private void Start()    
    {
        foreach (StartListener listener in startListeners)
        {
            listener.OnStart();
        }
        //bgmPlayer.Stop();
        //soundManager.SfxPlay(SoundManager.Sfx.drivingNormal);
        //Debug.Log(player.drunkGauge);
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
        foreach (Mission mission in Player.missionList) {
            if (mission.GetState()) count++;
        }

        Debug.Log("성공한 미션 갯수 " + count);

        finishBoardAnimator.SetBool("Result", true);
        Debug.Log("결과창 출력!");
        if(finishBoardAnimator.GetCurrentAnimatorStateInfo(0).IsName("Result") && finishBoardAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime == 1f)
        {
            Debug.Log("애니메이션 끝");
            //Time.timeScale = 0;
        }
    }

    public static void GameEnd1()
    {
        Time.timeScale = 0;
    }

}
