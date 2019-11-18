using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoUIBinder : UIObsever
{
    [SerializeField]
    private TextMeshProUGUI text;

    public override void BindUI(string _text)
    {
        text.text = _text;
    }
}
