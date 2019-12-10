using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventUIBinder : UIObsever
{
    [SerializeField]
    private TextMeshProUGUI text = default;

    [SerializeField]
    private EventUIAnimationController eventUIAnimationController = default;

    public override void BindUI(string _text)
    {
        text.text = _text;
        eventUIAnimationController.OpenScreen();
    }

}
