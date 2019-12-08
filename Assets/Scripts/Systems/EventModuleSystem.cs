using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventModuleSystem : IEModuleSystem
{
    [SerializeField]
    private EventCameraHandler eventCameraHandler = default;

    [SerializeField]
    protected UIObsever uiObserver = default;

    public virtual void Notify<T>(string txt)
        where T : UIObsever
    {
        uiObserver.BindUI(txt);
    }

    public override void TurnFinishUnit()
    {
        eventCameraHandler.ProcessEvents();
    }

    public override void Exit()
    {

    }

    public override void Initialize()
    {
        eventCameraHandler.Initialize();
    }
}
