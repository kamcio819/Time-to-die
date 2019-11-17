using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilMineCreator : FactoryCreator
{
    public override GameObject ConstructObject()
    {
        GameObject mine = Resources.Load<GameObject>("OilMine");
        GameObject newMine = Instantiate(mine);
        return newMine;
    }
}
