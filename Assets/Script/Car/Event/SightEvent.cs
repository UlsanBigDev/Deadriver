using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SightEvent : DrunkEvent
{
    private Image image;

    public SightEvent(Image Panelimage)
    {
        this.image = Panelimage;
    }

    public override void Run()
    {
        Debug.Log("시야방해 디버프");
        image.color = new Color(255, 255, 255, 50);
    }
}
