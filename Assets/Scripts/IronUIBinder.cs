using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IronUIBinder : UIObsever
{
    [SerializeField]
    private TextMeshProUGUI text = default;

    public override void BindUI(string _text)
    {
        text.text = _text;
    }
}
