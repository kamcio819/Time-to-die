using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputModuleSystem : TModuleSystem
{
    [SerializeField]
    private CursorInput cursorInput = default;

    [SerializeField]
    private KeyboardInput keyboardInput = default;

    public override void Tick()
    {
        cursorInput.OnUpdate();
        keyboardInput.OnUpdate();
    }
}
