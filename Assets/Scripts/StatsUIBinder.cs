using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsUIBinder : UIObsever
{
    [SerializeField]
    private TextMeshProUGUI text = default;

    public override void BindUI(string _text)
    {
        float value = float.Parse(text.text);
        value += float.Parse(_text);
        text.text = value.ToString();
    }
}
