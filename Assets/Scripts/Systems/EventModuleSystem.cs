using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventModuleSystem : IEModuleSystem
{
    [SerializeField]
    protected UIObsever uiObserver;

    public virtual void Notify<T>(string txt)
        where T : UIObsever
    {
        uiObserver.BindUI(txt);
    }

    public override void TurnFinishUnit()
    {
        
    }

    public override void Exit()
    {
    }

    public override void Initialize()
    {
    }
}
