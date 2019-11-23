using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button<T> : MonoBehaviour
{
    [SerializeField]
    private T type = default;

    public Action<T> ButtonPressed = default;

    public void Select()
    {
        ButtonPressed?.Invoke(type);
    }
}
