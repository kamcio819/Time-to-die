using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilMineController : MineController
{
    public override int ProduceMaterial(MaterialsData matData)
    {
        matData.AddOil(goodAmount);
        return goodAmount;
    }
}
