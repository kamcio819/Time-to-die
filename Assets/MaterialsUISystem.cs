using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsUISystem : MonoBehaviour
{
    [SerializeField]
    private List<UIObsever> uIMaterialsObservers;

    public void Notify()
    {
        //Add structure

        for (int i = 0; i < uIMaterialsObservers.Count; i++)
        {
            uIMaterialsObservers[i].BindUI("2");
        }
    }

    public void AddObserver(UIObsever observer)
    {
        uIMaterialsObservers.Add(observer);
    }

}
