using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AIGameTreeProcesserModule : MonoBehaviour
{
    private static ShipModuleSystem shipModuleSystem;
    private static UpgradeModuleSystem upgradeModuleSystem;
    private static MaterialsModuleSystem materialsModuleSystem;
    private static MapModuleSystem mapModuleSystem;

    private static List<GameObject> seaTiles = new List<GameObject>();

    public static Action<Vector3> GameTreeAction;

    private void Awake()
    {
        shipModuleSystem = FindObjectOfType<ShipModuleSystem>();
        upgradeModuleSystem = FindObjectOfType<UpgradeModuleSystem>();
        materialsModuleSystem = FindObjectOfType<MaterialsModuleSystem>();
        mapModuleSystem = FindObjectOfType<MapModuleSystem>();
    }

    private void Start()
    {
        seaTiles = mapModuleSystem.Tiles.FindAll(x => x.GetComponent<HexTile>().tileType == MapSystem.Type.SEA);
    }

    public static bool AITryToShoot(ShipState shipState)
    {
        List<Vector3> positions = new List<Vector3>();
        for (int i = 0; i < shipModuleSystem.PlayerShips.Count; ++i)
        {
            positions.AddRange(FindPlayerAttackPoistions(shipModuleSystem.PlayerShips[i].transform.position, shipState));
        }

        positions = positions.Distinct().ToList();

        List<Vector3> shipsInRange = new List<Vector3>();

        for (int i = 0; i < positions.Count; ++i)
        {
            if (ShipInRange(shipState.Position, positions[i], shipState.ShipData.ShipDataContainer.GetAttackRange()))
            {
                shipsInRange.Add(positions[i]);
            }
        }

        if (shipsInRange.Count == 0)
        {
            return false;
        }

        shipState.EnemyPosition = FindMinDistance(shipsInRange, shipState.Position);

        if (shipsInRange.Count > 0)
        {
            return true;
        }

        return false;
    }

    public static void AITryToMove(ShipState shipState)
    {
        int distance;
        List<Vector3> positions = new List<Vector3>();
        for(int i =0; i < shipModuleSystem.PlayerShips.Count; ++i)
        {
            positions.AddRange(FindPlayerShipPoistions(shipModuleSystem.PlayerShips[i].transform.position, shipState));
        }

        positions = positions.Distinct().ToList();

        for (int i = 0; i < positions.Count; ++i)
        {
            if (ShipInRange(shipState.Position, positions[i], shipState.ShipData.ShipDataContainer.GetMovementRange()))
            {
                distance = (int)(shipState.Position - positions[i]).magnitude;
                if (FindTilePosition(shipState, positions[i], distance/distance))
                {
                    shipState.ShipDistance = distance;
                    break;
                }
                continue;
            }
        }

        Vector3 shipPosition = positions[UnityEngine.Random.Range(0, positions.Count - 1)];
        distance = (int)(shipState.Position - shipPosition).magnitude;
        if (FindTilePosition(shipState, shipPosition, distance / 2))
        {
            shipState.ShipDistance = distance;
        }
    }

    public static void AIProcess(NodeAction nodeAction, ShipState shipState)
    {
        switch (nodeAction)
        {
            case NodeAction.MOVE:
                MoveShip(shipState);
                break;
            case NodeAction.SHOOT:
                ShootShip(shipState);
                break;
        }
    }

    private static void ShootShip(ShipState shipState)
    {
        GameObject shooterShip = shipModuleSystem.EnemyShips.Find(x => x.GetComponent<ShipController>().ShipType == shipState.ShipType);
        shooterShip.GetComponent<ShipAttackingController>().AttackPosition(shipState.EnemyPosition);
        GameTreeAction?.Invoke(shipState.EnemyPosition);
    }

    private static void MoveShip(ShipState shipState)
    {
        GameObject shipToMove = shipModuleSystem.EnemyShips.Find(x => x.GetComponent<ShipController>().ShipType == shipState.ShipType);
        shipToMove.GetComponent<ShipMovementController>().MoveToPosition(shipState.Position, 2f);
        GameTreeAction?.Invoke(shipState.Position);
    }

    private static List<Vector3> FindPlayerShipPoistions(Vector3 position, ShipState shipState)
    {
        return FindPositions(position, shipState.ShipData.ShipDataContainer.GetMovementRange(), shipState.Depth);
    }

    private static List<Vector3> FindPlayerAttackPoistions(Vector3 position, ShipState shipState)
    {
        return FindPositions(position, shipState.ShipData.ShipDataContainer.GetAttackRange(), shipState.Depth);
    }

    private static List<Vector3> FindPositions(Vector3 position, int range, int depth)
    {
        Collider[] tiles = Physics.OverlapSphere(position, range);
        List<Vector3> hexTiles = new List<Vector3>();
        for (int i = 0; i < tiles.Length; ++i)
        {
            HexTile hex = tiles[i].GetComponent<HexTile>();
            if(hex && hex.tileType == MapSystem.Type.SEA)
            {
                hexTiles.Add(hex.transform.position);
            }
        }


        if (depth < 0)
        {
            return null;
        }
        if (depth > 0)
        {
            hexTiles = FindPositions(hexTiles[UnityEngine.Random.Range(0, hexTiles.Count - 1)], range, depth - 1);
        }

        return hexTiles;

    }

    private static List<Vector3> FindPositions(Vector3 position, float range, int depth)
    {
        Collider[] tiles = Physics.OverlapSphere(position, range);
        List<Vector3> hexTiles = new List<Vector3>();
        for (int i = 0; i < tiles.Length; ++i)
        {
            HexTile hex = tiles[i].GetComponent<HexTile>();
            if (hex && hex.tileType == MapSystem.Type.SEA)
            {
                hexTiles.Add(hex.transform.position);
            }
        }


        if (depth < 0)
        {
            return null;
        }
        if (depth > 0)
        {
            hexTiles = FindPositions(hexTiles[UnityEngine.Random.Range(0, hexTiles.Count - 1)], range, depth - 1);
        }

        return hexTiles;

    }

    private static Vector3 FindMinDistance(List<Vector3> list, Vector3 position)
    {
        if (list.Count == 0)
        {
            throw new InvalidOperationException("Empty list");
        }

        int minDistance = int.MaxValue;
        Vector3 shipToFind = Vector3.zero;

        for (int i = 0; i < list.Count; ++i)
        {
            int distance = (int)(position - list[i]).magnitude;
            if (distance < minDistance)
            {
                minDistance = distance;
                shipToFind = list[i];
            }
        }

        return shipToFind;
    }

    private static bool FindTilePosition(ShipState shipState, Vector3 position2, int magnitude)
    {
        Vector3 newPos = shipState.Position;
        newPos.x += position2.x- shipState.Position.x  / magnitude;
        newPos.z += position2.z - shipState.Position.z / magnitude;
        for(int i = 0; i < seaTiles.Count; ++i)
        {
            if(CheckTilePos(newPos, seaTiles[i].transform.position))
            {
                shipState.Position = seaTiles[i].transform.position;
                return true;
            }
        }

        return false;
    }

    private static bool CheckTilePos(Vector3 newPos, Vector3 position)
    {
        if(Mathf.Abs(newPos.x - position.x) < 1f && Mathf.Abs(newPos.z - position.z) < 1f)
        {
            return true;
        }

        return false;
    }

    private static bool ShipInRange(Vector3 position, Vector3 position2, float range)
    {
        if (Mathf.Abs(position.x - position2.x) <= range && Mathf.Abs(position.z - position2.z) <= range)
        {
            return true;
        }
        return false;
    }
}