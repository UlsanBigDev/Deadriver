using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story
{
    List<string> messages;
    int index;
    public bool isLast;

    public Story(List<string> messages)
    {
        this.messages = messages;
        index = 0;
        isLast = false;
    }

    public string Now()
    {
        string message = messages[index++];
        if (index == messages.Count) isLast = true;
        return message;
    }

}
