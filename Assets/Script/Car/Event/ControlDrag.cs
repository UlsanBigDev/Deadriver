using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDrag : DrunkEvent
{
    //Vector3 movement;
    //Transform current;

    //public ControlDrag(Transform transform) //Transform transform = �Ű�����
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
        Debug.Log("����Ű �ݴ� �����");
        //MuMovement.rb.velocity = new Vector3(movement.x, MuMovement.rb.velocity.y, movement.z) * -1;     
    }
}
