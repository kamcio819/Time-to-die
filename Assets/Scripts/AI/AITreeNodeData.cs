using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipState
{
    public Vector3 position;
    public int shipDiffernce;
    public int shipDestroyed;
    public int shipDistance;

    public ShipType shipType;
    public ShipData shipData;

    public ShipState(Vector3 position, ShipType shipType, ShipData shipData , int shipDiffernce, int shipDestroyed)
    {
        this.position = position;
        this.shipType = shipType;
        this.shipData = shipData;
        this.shipDiffernce = shipDiffernce;
        this.shipDestroyed = shipDestroyed;
    }
}

[System.Serializable]
public class AITreeNodeData
{
    private float differenceWeight;
    private float destroyedWeight;
    private float distanceWeight;

    private ShipState gameState;

    public AITreeNodeData(float differenceWeight, float destroyedWeight, float distanceWeight, ShipState gameState)
    {
        this.differenceWeight = differenceWeight;
        this.destroyedWeight = destroyedWeight;
        this.distanceWeight = distanceWeight;
        this.gameState = gameState;
    }

    public float GetValue()
    {
        return differenceWeight * gameState.shipDiffernce + destroyedWeight * gameState.shipDestroyed - distanceWeight * gameState.shipDistance;
    }

    public void SetGameState(ShipState gameState)
    {
        this.gameState = gameState;
    }

    public ShipState GetGameState()
    {
        return this.gameState;
    }
}