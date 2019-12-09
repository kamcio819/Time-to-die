using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public Vector3 position;

    public GameState(Vector3 position)
    {
        this.position = position;
    }
}

public class AIGameTree : AIBehaviour
{
    [SerializeField]
    private AIModuleData AIModuleData;

    [SerializeField]
    private ShipModuleSystem shipModuleSystem;

    private Dictionary<GameObject, AITreeNode> ShipsTrees = new Dictionary<GameObject, AITreeNode>();

    public override void Process()
    {
        CreateTree();
        EvaluateTree();
    }

    private void EvaluateTree()
    {
        
    }

    private void CreateTree()
    {
        ShipsTrees.Clear();
        for (int i = 0; i < shipModuleSystem.EnemyShips.Count; ++i)
        {
            ShipsTrees.Add(shipModuleSystem.EnemyShips[i], GenerateTree(new AITreeNode(0.25f, 0.75f, 0.3f),4));
        }
    }

    private AITreeNode GenerateTree(AITreeNode node, int depth)
    {
        if (depth < 0) return null;

        AITreeNode currentNode = new AITreeNode(node, 0.25f, 0.75f, 0.3f);

        if (depth > 0)
        {
            currentNode.Left = GenerateTree(currentNode, depth - 1);
            currentNode.Right = GenerateTree(currentNode, depth - 1);
        }

        return currentNode;
    }

}
