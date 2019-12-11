using System;
using System.Collections.Generic;
using UnityEngine;

public class AIGameTree : AIBehaviour
{
    [SerializeField]
    private AIModuleData AIModuleData = default;

    [SerializeField]
    private ShipModuleSystem shipModuleSystem = default;

    private Dictionary<GameObject, AITreeNode> ShipsTrees = new Dictionary<GameObject, AITreeNode>();

    public override void Process()
    {
        CreateTree();
        EvaluateTree();
    }

    private void EvaluateTree()
    {
        for (int i = 0; i < shipModuleSystem.EnemyShips.Count; ++i)
        {
            AITreeNode lastNode = FindLastNode(ShipsTrees[shipModuleSystem.EnemyShips[i]]);
            lastNode.NodeParent.NodeParent.NodeParent.Execute?.Invoke();
        }
    }

    private AITreeNode FindLastNode(AITreeNode aITreeNode)
    {
        if(aITreeNode.Right != null && aITreeNode.Left != null)
        {
            if(aITreeNode.Left.NodeData.GetValue() > aITreeNode.Right.NodeData.GetValue())
            {
                return FindLastNode(aITreeNode.Left);
            }
            else
            {
                return FindLastNode(aITreeNode.Right);
            }
        }

        return aITreeNode;
    }

    private void CreateTree()
    {
        ShipsTrees.Clear();
        for (int i = 0; i < shipModuleSystem.EnemyShips.Count; ++i)
        {
            ShipController sController = shipModuleSystem.EnemyShips[i].GetComponent<ShipController>();
            ShipDataController sDataController = shipModuleSystem.EnemyShips[i].GetComponent<ShipDataController>();
            ShipsTrees.Add(shipModuleSystem.EnemyShips[i],
                GenerateTree(
                    new AITreeNode(new ShipState(shipModuleSystem.EnemyShips[i].transform.position, sController.ShipType, sDataController.ShipData, shipModuleSystem.PlayerShips.Count - shipModuleSystem.EnemyShips.Count, 0, CalculateShipDistance(shipModuleSystem.EnemyShips[i].transform.position), 0),
                                            0.25f,
                                            0.75f,
                                            0.3f,
                                            NodeAction.NONE
                    ),
                    4, 
                    NodeAction.NONE)
            );
        }
    }

    private int CalculateShipDistance(Vector3 position)
    {
        List<Vector3> positions = new List<Vector3>();
        for (int i = 0; i < shipModuleSystem.PlayerShips.Count; ++i)
        {
            positions.Add(shipModuleSystem.PlayerShips[i].transform.position);
        }

        int minDistance = (int)(FindMinDistance(positions, position) - position).magnitude;
        return minDistance;
    }

    private Vector3 FindMinDistance(List<Vector3> positions, Vector3 position)
    {
        if (positions.Count == 0)
        {
            throw new InvalidOperationException("Empty list");
        }

        int minDistance = int.MaxValue;
        Vector3 shipToFind = Vector3.zero;

        for (int i = 0; i < positions.Count; ++i)
        {
            int distance = (int)(position - positions[i]).magnitude;
            if (distance < minDistance)
            {
                minDistance = distance;
                shipToFind = positions[i];
            }
        }

        return shipToFind;
    }

    private AITreeNode GenerateTree(AITreeNode node, int depth, NodeAction nodeAction)
    {
        if (depth < 0)
        {
            return null;
        }

        AITreeNode currentNode = new AITreeNode(node, node.GetGameState(), 0.25f, 0.75f, 0.3f, nodeAction);

        if (depth > 0)
        {
            node.GetGameState().Depth++;
            currentNode.Left = GenerateTree(currentNode, depth - 1, NodeAction.SHOOT);
            currentNode.Right = GenerateTree(currentNode, depth - 1, NodeAction.MOVE);
        }

        return currentNode;
    }

}
