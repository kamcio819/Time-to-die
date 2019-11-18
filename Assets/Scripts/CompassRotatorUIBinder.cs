using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassRotatorUIBinder : UIObsever
{
    [SerializeField]
    private Text text;

    public override void BindUI(string _text)
    {
        text.text = _text;
    }
}
