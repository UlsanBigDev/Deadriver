using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story
{
    protected List<string> messages;
    protected int index;
    public bool isLast;
    protected System.Action OnLoad;

    public Story(List<string> messages)
    {
        this.messages = messages;
        index = 0;
        isLast = false;
    }

    public Story(List<string> messages, System.Action action) : this(messages)
    {
        this.OnLoad = action;
    } 

    public string Now()
    {
        string message = messages[index++];
        if (index == messages.Count) isLast = true;
        return message;
    }

    public void Reset()
    {
        index = 0;
        isLast = false;
    }

    public void Run()
    {
        OnLoad?.Invoke();
    }

}
