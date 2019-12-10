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
                    new AITreeNode(new ShipState(shipModuleSystem.EnemyShips[i].transform.position, sController.ShipType, sDataController.ShipData, shipModuleSystem.PlayerShips.Count - shipModuleSystem.EnemyShips.Count, 0),
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

    private AITreeNode GenerateTree(AITreeNode node, int depth, NodeAction nodeAction)
    {
        if (depth < 0)
        {
            return null;
        }

        AITreeNode currentNode = new AITreeNode(node, node.GetGameState(), 0.25f, 0.75f, 0.3f, nodeAction);

        if (depth > 0)
        {
            currentNode.Left = GenerateTree(currentNode, depth - 1, NodeAction.SHOOT);
            currentNode.Right = GenerateTree(currentNode, depth - 1, NodeAction.MOVE);
        }

        return currentNode;
    }

}
