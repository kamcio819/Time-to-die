using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button<T> : MonoBehaviour
{
    [SerializeField]
    private T type;

    public Action<T> ButtonPressed;

    public void Select()
    {
        ButtonPressed?.Invoke(type);
    }
}
