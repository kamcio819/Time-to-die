using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MineController : MonoBehaviour
{
    [SerializeField]
    protected int goodAmount;

    public abstract int ProduceMaterial(ref MaterialsModuleSystem.MaterialsData matData);
}
