using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineUISwitcher : Button<MineType>
{
    public Image image = default;

    public void TurnOffUI(Color color)
    {
        image.color = color;
    }

    public void TurnOnUI(Color color)
    {
        image.color = color;
    }
}
