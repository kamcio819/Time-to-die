using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicModulesManager : MonoBehaviour
{
    [SerializeField]
    private List<ITEModuleSystem> iteModules = default;

    [SerializeField]
    private List<ITModuleSystem> itModules = default;

    [SerializeField]
    private List<TEModuleSystem> teModules = default;

    [SerializeField]
    private List<TModuleSystem> tModules = default;

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
