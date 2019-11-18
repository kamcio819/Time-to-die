using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OilUIBinder : UIObsever
{
    [SerializeField]
    private TextMeshProUGUI text;

    public override void BindUI(string _text)
    {
        text.text = _text;
    }
}
