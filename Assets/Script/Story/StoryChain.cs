using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryChain : Story
{
    public Story next;
    public StoryChain(List<StoryScript> scripts, Story story) : base(scripts)
    {
        next = story;
    }

    public StoryChain(List<StoryScript> scripts, Story story, System.Action listener) : this(scripts, story)
    {
        OnLoad = listener;
    }
}
