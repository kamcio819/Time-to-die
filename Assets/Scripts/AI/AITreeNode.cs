using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class AITreeNode
{
    [SerializeField]
    private AITreeNodeData nodeData;

    [SerializeField]
    private AITreeNode left;

    [SerializeField]
    private AITreeNode right;

    [SerializeField]
    private AITreeNode nodeParent;

    public AITreeNode NodeParent { get => nodeParent; set => nodeParent = value; }
    public AITreeNodeData NodeData { get => nodeData; }
    public AITreeNode Left { get => left; set => left = value; }
    public AITreeNode Right { get => right; set => right = value; }

    public AITreeNode(AITreeNode parent, float differenceWeight, float destroyedWeight, float distanceWeight)
    {
        nodeData = new AITreeNodeData(differenceWeight, destroyedWeight, distanceWeight);
        nodeParent = parent;
    }

    public AITreeNode(float differenceWeight, float destroyedWeight, float distanceWeight)
    {
        nodeData = new AITreeNodeData(differenceWeight, destroyedWeight, distanceWeight);
        nodeParent = null;
    }

    public AITreeNode GetLeft()
    {
        return Left;
    }

    public AITreeNode GetRight()
    {
        return Right;
    }

    public void SetShipDiffernce(int diff)
    {
        nodeData.SetShipDiffernce(diff);
    }

    public void SetShipDestroyed(int dest)
    {
        nodeData.SetShipDestroyed(dest);
    }

    public void SetShipDistance(float dist)
    {
        nodeData.SetShipDistance(dist);
    }

}
