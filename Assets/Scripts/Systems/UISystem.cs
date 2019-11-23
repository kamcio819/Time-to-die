using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UISystem : MonoBehaviour
{
    [SerializeField]
    protected List<UIObsever> uiObservers;

    public virtual void Notify<T>(string txt)
        where T : UIObsever
    {
        var observer = uiObservers.Find(x => x as T);
        observer.BindUI(txt);
    }

    public virtual void AddObserver(UIObsever observer)
    {
        uiObservers.Add(observer);
    }
}
