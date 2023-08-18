using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SightEvent : DrunkEvent
{
    private Image image;

    public SightEvent(Image panelImage)
    {
        this.image = panelImage;
    }

    public void sight()
    {
        Debug.Log("시야방해 디버프");
        image.color = new Color(255, 255, 255, 20);
    }

    public override void Run()
    {
        sight();
    }
}
