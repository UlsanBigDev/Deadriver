using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDrag : DrunkEvent
{
    //Vector3 movement;
    //Transform current;

    //public ControlDrag(Transform transform) //Transform transform = 매개변수
    //{
    //    current = transform;
    //}

    //public void Control()
    //{
    //    float v = Input.GetAxis("Vertical");
    //    this.movement = current.forward * v * MuMovement.currentSpeed;
    //}

    public override void Run()
    {
        Debug.Log("조작키 반대 디버프");
        //MuMovement.rb.velocity = new Vector3(movement.x, MuMovement.rb.velocity.y, movement.z) * -1;     
    }
}
