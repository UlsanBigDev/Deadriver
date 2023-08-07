using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    [SerializeField]
    StoryChat storyChat;

    private void Awake()
    {
        
    }
    private void Start()
    {
        storyChat.PrintStoryChatText("꺌룰랭 asdfsdaf");
    }
}
