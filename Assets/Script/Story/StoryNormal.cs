using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryNormal : Story
{
    Story nextStory;
    public StoryNormal(List<string> message, Story story) : base(message)
    {
        nextStory = story;
    }

    public StoryNormal(List<string> message, Story story, System.Action listener) : this(message, story)
    {
        OnLoad = listener;
    }
}
