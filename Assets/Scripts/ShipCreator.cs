using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public abstract class FactoryCreator : MonoBehaviour
{
    public abstract GameObject ConstructObject(PlayerType pT);
}
