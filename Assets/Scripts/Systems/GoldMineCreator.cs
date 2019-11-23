using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMineCreator : FactoryCreator
{
    public override GameObject ConstructObject(PlayerType playerType)
    {
        GameObject mine = Resources.Load<GameObject>("GoldMine");
        GameObject newMine = Instantiate(mine);
        newMine.GetComponent<MineController>().SetOwner(playerType);
        return newMine;
    }
}
