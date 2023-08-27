using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct StoryScript
{
    public string message;
    public System.Action action;

    public StoryScript(string message)
    {
        this.message = message;
        this.action = null;
    }

    public StoryScript(string message, System.Action callback) : this (message)
    {   
        this.action = callback;
    }


}

/// <summary>
/// 스토리 클레스로 스토리 미션중 플레이어가 NPC와 대화할때 스크립트를 다룸
/// </summary>
public class Story
{
    /// <summary>
    /// 스크립트 대화 리스트로 0 ~ N 번째 순으로 SPACE바로 다음 대화가 읽힘
    /// </summary>
    protected List<StoryScript> scripts;
    /// <summary>
    /// 현재 Story messages의 인데스
    /// </summary>
    protected int index;
    /// <summary>
    /// 현재 Story의 대화가 마지막인지 아닌지
    /// </summary>
    public bool isLast;

    /// <summary>
    /// 스토리가 읽히는 시점에 CallBack
    /// </summary>
    protected System.Action OnLoad;

    public Story(List<StoryScript> scripts)
    {
        this.scripts = scripts;
        index = 0;
        isLast = false;
    }

    public Story(List<StoryScript> scripts, System.Action action) : this(scripts)
    {
        this.OnLoad = action;
    } 

    /// <summary>
    /// 현재 스토리의 인덱스의 대화를 리턴함
    /// </summary>
    public string Now()
    {   
        StoryScript script = this.scripts[index++];
        if (index == scripts.Count) isLast = true;        
        script.action?.Invoke();
        return script.message;
        /*string message = messages[index++];
        if (index == messages.Count) isLast = true;
        return message;*/
    }

    /// <summary>
    /// 대화를 다시 읽을때를 대비해서 리셋 하는 함
    /// </summary>
    public void Reset()
    {
        index = 0;
        isLast = false;
    }

    /// <summary>
    /// callBack 함수 실행으로 StoryManager에서 Run()함수를 호출 중이지만
    /// Now() 함수쪽에서 호출 하는 식으로 바꿀 확률 있음
    /// </summary>
    public void Run()
    {
        OnLoad?.Invoke();
    }

}
