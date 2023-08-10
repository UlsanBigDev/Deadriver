using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StoryTitle
{
    public string title;
    public int id;
    public StoryTitle(string title, int id)
    {
        this.title = title;
        this.id = id;
    }
}
public class StorySelect : Story
{
    public StoryTitle s1;
    public StoryTitle s2;
    public StorySelect(List<string> message, (StoryTitle, StoryTitle) storys) : base(message)
    {
        s1 = storys.Item1;
        s2 = storys.Item2;
    }
}
