using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Person : AbstractEnemy
{
    PersonBlood personBlood;

    public GameObject person;
    Animator anim;
    public float speed;
    private Rigidbody rigid;

    private void Awake()
    {
        personBlood = new PersonBlood();
        anim = person.GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        
    }

    private void OnEnable()
    {
        rigid.velocity = new Vector3(0, 0);
    }
    /* 사람이랑 충돌됐는지 알려주는 코드 */
    //사람이랑 충돌되면 이 스크립트가 실행
    protected override void OnPlayerCrash(Player player)
    {
        Debug.Log("사람 충돌");
        personBlood.ShowBlood();
        anim.SetBool("Hit", true);;  
    }
}
