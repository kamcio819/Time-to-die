﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronMineController : MineController
{
    public override int ProduceMaterial(MaterialsData matData)
    {
        matData.AddIron(goodAmount);
        return goodAmount;
    }
}
