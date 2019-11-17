using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMineCreator : FactoryCreator
{
    public override GameObject ConstructObject()
    {
        GameObject mine = Resources.Load<GameObject>("GoldMine");
        GameObject newMine = Instantiate(mine);
        return newMine;
    }
}
