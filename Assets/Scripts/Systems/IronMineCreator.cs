using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronMineCreator : FactoryCreator
{
    public override GameObject ConstructObject(PlayerType playerType)
    {
        GameObject mine = Resources.Load<GameObject>("IronMine");
        GameObject newMine = Instantiate(mine);
        newMine.GetComponent<MineController>().SetOwner(playerType);
        return newMine;
    }
}
