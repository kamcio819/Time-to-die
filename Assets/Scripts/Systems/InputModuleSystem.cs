using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputModuleSystem : TModuleSystem
{
    [SerializeField]
    private CursorInput cursorInput;

    [SerializeField]
    private KeyboardInput keyboardInput;

    public override void Tick()
    {
        cursorInput.OnUpdate();
        keyboardInput.OnUpdate();
    }
}
