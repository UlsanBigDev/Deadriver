using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StoryTitle
{
    string title;
    Story story;
    StoryTitle(string title, Story story)
    {
        this.title = title;
        this.story = story;
    }
}
public class StorySelect : Story
{
    StoryTitle s1;
    StoryTitle s2;
    public StorySelect(List<string> message, (StoryTitle, StoryTitle) storys) : base(message)
    {
        s1 = storys.Item1;
        s2 = storys.Item2;
    }
}
