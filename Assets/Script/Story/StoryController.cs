using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    [SerializeField]
    private int storyId;

    private Story current;

    private void Update()
    {
        Reading();
        
    }
    private void Reading()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}
