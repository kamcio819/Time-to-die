using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMineController : MineController
{
    public override int ProduceMaterial(MaterialsData matData)
    {
        matData.AddGold(goodAmount);
        return goodAmount;
    }
}
