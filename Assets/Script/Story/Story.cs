using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story
{
    int id;
    List<string> messages;
    int index;
    bool isLast;

    public Story(int id, List<string> messages)
    {
        this.id = id;
        this.messages = messages;
        index = 0;
    }

}
