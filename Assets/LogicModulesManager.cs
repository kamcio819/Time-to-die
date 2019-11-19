using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicModulesManager : MonoBehaviour
{
    [SerializeField]
    private List<ITEModuleSystem> iteModules;

    [SerializeField]
    private List<ITModuleSystem> itModules;

    [SerializeField]
    private List<TEModuleSystem> teModules;

    [SerializeField]
    private List<TModuleSystem> tModules;

    private void Update()
    {
        for(int i = 0; i < iteModules.Count; ++i)
        {
            iteModules[i].Tick();
        }

        for (int i = 0; i < itModules.Count; ++i)
        {
            itModules[i].Tick();
        }

        for (int i = 0; i < teModules.Count; ++i)
        {
            teModules[i].Tick();
        }

        for (int i = 0; i < tModules.Count; ++i)
        {
            tModules[i].Tick();
        }
    }
}
