using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform[] GreenArray;
    public Transform[] YELLOWArray;
    public Transform[] ORANGEArray;
    public Transform[] REDArray;

    Player player;
    ObstacleEvent obstacleEvent;
    SightEvent sightEvent;

    public Image panel;
    public GameObject drag;

    private void Awake() //디버프를 drunkEvents 리스트에 추가(Add)해줌
    {
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
    }

    private void Start()    
    {
        //Debug.Log(player.drunkGauge);
    }
}
