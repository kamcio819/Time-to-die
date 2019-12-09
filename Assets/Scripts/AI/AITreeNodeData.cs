using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AITreeNodeData
{
    private float differenceWeight;
    private float destroyedWeight;
    private float distanceWeight;

    private int shipDifference;
    private int shipDestroyed;
    private float shipDistance;

    public AITreeNodeData(float differenceWeight, float destroyedWeight, float distanceWeight)
    {
        this.differenceWeight = differenceWeight;
        this.destroyedWeight = destroyedWeight;
        this.distanceWeight = distanceWeight;
    }

    public void SetShipDiffernce(int diff)
    {
        shipDifference = diff;
    }

    public void SetShipDestroyed(int dest)
    {
        shipDestroyed = dest;
    }

    public void SetShipDistance(float distance)
    {
        shipDistance = distance;
    }

    public float GetValue()
    {
        return differenceWeight * shipDifference + destroyedWeight * shipDestroyed - distanceWeight * shipDistance;
    }
}