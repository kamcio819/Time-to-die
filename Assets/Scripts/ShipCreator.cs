using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public abstract class ShipCreator : MonoBehaviour
{
    public abstract GameObject ConstructShip();
}
