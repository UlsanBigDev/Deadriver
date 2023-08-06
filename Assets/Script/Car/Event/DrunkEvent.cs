using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DrunkEvent // 음주이벤트 => 방향키어쩌구이벤트, 속도 조작 어쩌구, 핸들링 빡세짐
{ //추상클래스 -> 상속 받아서 안에 내용을 내가 원하는 걸로 적어주면 됨
  
    public abstract void Run(); // 음주이벤트를 실행하는 함수
}