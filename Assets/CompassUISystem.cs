using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassUISystem : MonoBehaviour
{
    [SerializeField]
    private List<UIObsever> compassObservers;

    public void Notify()
    {
        //Add structure

        for (int i = 0; i < compassObservers.Count; i++)
        {
            compassObservers[i].BindUI(Time.time.ToString());
        }
    }

    public void AddObserver(UIObsever observer)
    {
        compassObservers.Add(observer);
    }
}
