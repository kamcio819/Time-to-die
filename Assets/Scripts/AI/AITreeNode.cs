using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum NodeAction
{
    MOVE,
    SHOOT,
    NONE
}

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

    public AITreeNode(AITreeNode parent, ShipState gameState, float differenceWeight, float destroyedWeight, float distanceWeight, NodeAction nodeAction)
    {
        ProcessActionGameState(gameState, nodeAction);
        nodeData = new AITreeNodeData(differenceWeight, destroyedWeight, distanceWeight, gameState);
        nodeParent = parent;
    }

    public AITreeNode(ShipState gameState, float differenceWeight, float destroyedWeight, float distanceWeight, NodeAction nodeAction)
    {
        nodeData = new AITreeNodeData(differenceWeight, destroyedWeight, distanceWeight, gameState);
        nodeParent = null;
    }

    private void ProcessActionGameState(ShipState gameState, NodeAction nodeAction)
    {
        switch(nodeAction)
        {
            case NodeAction.SHOOT:
                TryToShootFromPosition(gameState);
                break;
            case NodeAction.MOVE:
                MovePosition(gameState);
                break;
        }
    }

    private void MovePosition(ShipState gameState)
    {
        AIGameTreeProcesserModule.AITryToMove(gameState);
    }

    private void TryToShootFromPosition(ShipState gameState)
    {
        if(AIGameTreeProcesserModule.AITryToShoot(gameState.position, gameState.shipData.ShipDataContainer.GetAttackRange())) 
        {
            gameState.shipDestroyed++;
            gameState.shipDiffernce--;
        }
    }

    public AITreeNode GetLeft()
    {
        return Left;
    }

    public AITreeNode GetRight()
    {
        return Right;
    }

    public void SetGameState(ShipState gameState)
    {
        nodeData.SetGameState(gameState);
    }

    public ShipState GetGameState()
    {
        return nodeData.GetGameState();
    }
}
