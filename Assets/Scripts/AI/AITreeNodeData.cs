using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipState
{
    public Vector3 Position;
    public int ShipDiffernce;
    public int ShipDestroyed;
    public int ShipDistance;

    public ShipType ShipType;
    public ShipData ShipData;

    public int Depth;

    public ShipState(ShipState shipState)
    {
        this.Position = shipState.Position;
        this.ShipType = shipState.ShipType;
        this.ShipData = shipState.ShipData;
        this.ShipDiffernce = shipState.ShipDiffernce;
        this.ShipDestroyed = shipState.ShipDestroyed;
        this.Depth = shipState.Depth;
    }

    public ShipState(Vector3 position, ShipType shipType, ShipData shipData , int shipDiffernce, int shipDestroyed, int depth)
    {
        this.Position = position;
        this.ShipType = shipType;
        this.ShipData = shipData;
        this.ShipDiffernce = shipDiffernce;
        this.ShipDestroyed = shipDestroyed;
        this.Depth = depth;
    }
}

[System.Serializable]
public class AITreeNodeData
{
    private float differenceWeight;
    private float destroyedWeight;
    private float distanceWeight;

    private ShipState shipState;

    public AITreeNodeData(float differenceWeight, float destroyedWeight, float distanceWeight, ShipState shipState)
    {
        this.differenceWeight = differenceWeight;
        this.destroyedWeight = destroyedWeight;
        this.distanceWeight = distanceWeight;
        this.shipState = shipState;
    }

    public float GetValue()
    {
        return differenceWeight * shipState.ShipDiffernce + destroyedWeight * shipState.ShipDestroyed - distanceWeight * shipState.ShipDistance;
    }

    public void SetGameState(ShipState gameState)
    {
        this.shipState = gameState;
    }

    public ShipState GetGameState()
    {
        return this.shipState;
    }
}