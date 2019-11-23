using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button<T> : MonoBehaviour
{
    [SerializeField]
    private T type = default;

    public Action<T> ButtonPressed = default;
    public T Type { get => type; }

    public void Select()
    {
        ButtonPressed?.Invoke(type);
    }
}
