using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryNormal : Story
{
    public Story next;
    public StoryNormal(List<string> message, Story story) : base(message)
    {
        next = story;
    }

    public StoryNormal(List<string> message, Story story, System.Action listener) : this(message, story)
    {
        OnLoad = listener;
    }
}
