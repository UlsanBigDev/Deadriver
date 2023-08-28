using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 스토리 선택지에서 출력할 정보 구조체
/// ex) [간다] [안간다] 이런거임
/// </summary>
public struct StoryTitle
{
    public string title;
    public int id;
    public bool isSceneChange;
    public StoryTitle(string title, int id)
    {
        this.title = title;
        this.id = id;
        isSceneChange = true;
    }

    public StoryTitle(string title, int id, bool state) : this(title, id)
    {
        isSceneChange = state;
    }
}

/// <summary>
/// Story를 상속 받는 StorySelect 스토리 선택지 버튼 2개를 포함 하고있는 클레스임 앵간하면 이거 쓰일듯
/// </summary>
public class StorySelect : Story
{
    public StoryTitle s1;
    public StoryTitle s2;

    /// <summary>
    /// 생성자
    /// </summary>
    public StorySelect(List<StoryScript> scripts, (StoryTitle, StoryTitle) storys) : base(scripts)
    {
        s1 = storys.Item1;
        s2 = storys.Item2;
    }

    public StorySelect(List<StoryScript> scripts, (StoryTitle, StoryTitle) storys, System.Action action) : this(scripts, storys)
    {
        OnLoad = action;
    }
}
