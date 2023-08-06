using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class ControlEvent : DrunkEvent
{
    public static Transform current;
    Vector3 movement;
    public ControlEvent() { }

    public ControlEvent(Transform transform)
    {
        current = transform;
    }

    public override void Run()
    {
        float v = Input.GetAxis("Vertical");
        movement = ControlEvent.current.forward * v * PlayerCarMovement.currentSpeed;

        PlayerCarMovement.rb.velocity = new Vector3(movement.x, PlayerCarMovement.rb.velocity.y, movement.z) * -1;
        Debug.Log("조작키 반대 디버프");
    }
}
