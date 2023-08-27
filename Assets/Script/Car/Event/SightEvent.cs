using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SightEvent : DrunkEvent //Panel의 투명도를 이용해서 시야 방해 디버프를 만듬
{
    public Image image;
    private DrunkLevel level;
    public Animator anim;

    public SightEvent(Image panel)
    {
        this.image = panel;
        level = Player.GetPlayer().drunkLevel;
    }

    public override void Run()
    {
        /*Sight();*/
    }

    private void Sighting()
    {

    }

    public void Sight()
    {
        Debug.Log("시야방해 디버프");

        //난이도별로 투명도를 증가시켜서 더 흐리게 만듬
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

    
}
