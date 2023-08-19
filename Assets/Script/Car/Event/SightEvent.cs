using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SightEvent : DrunkEvent
{
    public Image image;

    public SightEvent(Image panelImage)
    {
        this.image = panelImage;
    }

    public void sight()
    {
        Debug.Log(image);
        Debug.Log("시야방해 디버프");
        image.color = new Color(255, 255, 255, 0.5f);
    }

    public override void Run()
    {
        sight();
    }
}
