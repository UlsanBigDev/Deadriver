using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionDrag : MonoBehaviour
{
    Vector3 movement;
    Transform current;

    public DirectionDrag() { }
    public DirectionDrag(Transform transform) //Transform transform = �Ű�����
    {
        current = transform;
    }

    public void Direction()
    {
        float v = Input.GetAxis("Vertical");
        this.movement = current.forward * v * MuMovement.currentSpeed;
    }

    public void DragDirection()
    {
        MuMovement.rb.velocity = new Vector3(movement.x, MuMovement.rb.velocity.y, movement.z) * -1;
    }

    public static void SpeedRotation() //ȸ�� �ӵ��� �� ������
    {
        MuMovement.rotationSpeed = 150F;
    }

 
}
