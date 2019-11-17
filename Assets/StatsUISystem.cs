using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsUISystem : MonoBehaviour
{
    [SerializeField]
    private List<UIObsever> statusObservers;

    public void Notify()
    {
        //Add structure

        for (int i = 0; i < statusObservers.Count; i++)
        {
            statusObservers[i].BindUI("3");
        }
    }

    public void AddObserver(UIObsever observer)
    {
        statusObservers.Add(observer);
    }
}
