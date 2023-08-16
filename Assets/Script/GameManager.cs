using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] GreenArray;
    public Transform[] YELLOWArray;
    public Transform[] ORANGEArray;
    public Transform[] REDArray;

    Player player;
    public ObstacleEvent obstacleEvent;

    public GameObject drag;

    private void Awake() //디버프를 drunkEvents 리스트에 추가(Add)해줌
    {
        player = Player.GetPlayer();
        //Start로 하면 AbstractCar 스크립트에서의 Start에서 foreach문으로 리스트의 Run을 호출하는거랑
        //여기서 Add하는 거랑 동시에 일어나기 때문에 Add를 먼저 해준 후에 리스트의 Run들을 호출해야하니까 여기는 Awake로
        /* Awake( 리스트에 Add ) -> Start( 리스트에 Add 된 값들에 해당하는 Run을 실행 ) */

        //Car.AddDrunkEvent(new RashEvent());
        //Car.AddDrunkEvent(new RotationEvent());
        //Car.AddDrunkEvent(new ControlEvent()); 
        if(Player.GetPlayer().drunkLevel == DrunkLevel.GREEN )
        {
            Car.AddDrunkEvent(new ObstacleEvent(GreenArray, drag));
            obstacleEvent = new ObstacleEvent(GreenArray, drag);
            //drag Object를 ObstacleEvent에서 지정해주는 게 아니라 여기서 drag Object를 지정해주고 전달해야함
            //ObstacleEvent에서 지정하니까 초기화가 되는 듯?
        }        
    }

    private void Start()    
    {
        Debug.Log(player.drunkGauge);
    }
}
