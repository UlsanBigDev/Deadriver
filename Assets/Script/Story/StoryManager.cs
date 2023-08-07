using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    static List<Story> storyList = new List<Story>();

    [SerializeField]
    StoryChat storyChat;

    private void Awake()
    {
        storyList.Add(new Story(0, new List<string>(){"aaa", "bbb"})); // 데이터 임시 하드코딩
    }
    private void Start()
    {
        storyChat.PrintStoryChatText("꺌룰랭 asdfsdaf");
    }
}
