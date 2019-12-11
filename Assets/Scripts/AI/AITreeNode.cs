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

    public Action Execute;

    public AITreeNode(AITreeNode parent, ShipState shipState, float differenceWeight, float destroyedWeight, float distanceWeight, NodeAction nodeAction)
    {
        ShipState newState = new ShipState(shipState);
        ProcessActionGameState(newState, nodeAction);
        nodeData = new AITreeNodeData(differenceWeight, destroyedWeight, distanceWeight, newState);
        nodeParent = parent;
        Execute += () => { AIGameTreeProcesserModule.AIProcess(nodeAction, shipState); };
    }

    public AITreeNode(ShipState shipState, float differenceWeight, float destroyedWeight, float distanceWeight, NodeAction nodeAction)
    {
        ShipState newState = new ShipState(shipState);
        nodeData = new AITreeNodeData(differenceWeight, destroyedWeight, distanceWeight, newState);
        nodeParent = null;
    }

    private void ProcessActionGameState(ShipState gameState, NodeAction nodeAction)
    {
        switch (nodeAction)
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
        if(AIGameTreeProcesserModule.AITryToShoot(gameState)) 
        {
            gameState.ShipDestroyed++;
            gameState.ShipDiffernce--;
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
