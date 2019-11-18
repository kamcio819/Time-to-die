using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronMineCreator : FactoryCreator
{
    public override GameObject ConstructObject()
    {
        GameObject mine = Resources.Load<GameObject>("IronMine");
        GameObject newMine = Instantiate(mine);
        return newMine;
    }
}
