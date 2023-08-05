using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DrunkEvent // 음주이벤트 => 방향키어쩌구이벤트, 속도 조작 어쩌구, 핸들링 빡세짐
{
    public abstract void Run(); // 음주이벤트를 실행하는 함수
}