using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryChain : Story
{
    public Story next;
    public StoryChain(List<string> message, Story story) : base(message)
    {
        next = story;
    }

    public StoryChain(List<string> message, Story story, System.Action listener) : this(message, story)
    {
        OnLoad = listener;
    }
}
