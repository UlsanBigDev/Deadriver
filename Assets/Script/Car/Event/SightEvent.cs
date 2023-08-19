using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SightEvent : DrunkEvent
{
    public Image image;
    DrunkLevel level = Player.GetPlayer().drunkLevel;

    public SightEvent(Image panel)
    {
        this.image = panel;
    }

    public void sight()
    {
        Debug.Log("시야방해 디버프");

        if (level == DrunkLevel.GREEN)
        {
           image.color = new Color(255, 255, 255);
            Debug.Log("GREEN 시야방해");
        }
        else if (level == DrunkLevel.YELLOW)
        {
            image.color = new Color(255, 255, 255, 0.1F);
            Debug.Log("YELLOW 시야방해");
        }
        else if (level == DrunkLevel.ORANGE)
        {
            image.color = new Color(255, 255, 255, 0.2F);
            Debug.Log("ORANGE 시야방해");
        }
        else if (level == DrunkLevel.RED)
        {
            image.color = new Color(255, 255, 255, 0.3F);
            Debug.Log("RED 시야방해");
        }
        
    }

    public override void Run()
    {
        sight();
    }
}
