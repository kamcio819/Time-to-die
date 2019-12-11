using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGameTreeProcesserModule : MonoBehaviour
{
    private static ShipModuleSystem shipModuleSystem;
    private static UpgradeModuleSystem upgradeModuleSystem;
    private static MaterialsModuleSystem materialsModuleSystem;
    private static MapModuleSystem mapModuleSystem;

    private static List<GameObject> seaTiles = new List<GameObject>();

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

    public static bool AITryToShoot(Vector3 position, float range)
    {
        for (int i = 0; i < shipModuleSystem.PlayerShips.Count; ++i)
        {
            if (ShipInRange(position, shipModuleSystem.PlayerShips[i].transform.position, range))
            {
                return true;
            }
        }
        return false;
    }

    private static bool ShipInRange(Vector3 position, Vector3 position2, float range)
    {
        if(Mathf.Abs(position.x - position2.x) <= range && Mathf.Abs(position.z - position2.z) <= range)
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

        Vector3 shipPosition = positions[UnityEngine.Random.Range(0, positions.Count)];
        distance = (int)(shipState.Position - shipPosition).magnitude;
        if (FindTilePosition(shipState, shipPosition, distance))
        {
            shipState.ShipDistance = distance;
        }
    }

    private static List<Vector3> FindPlayerShipPoistions(Vector3 position, ShipState shipState)
    {
        return FindPositions(position, shipState.ShipData.ShipDataContainer.GetMovementRange(), shipState.Depth);
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

    private static bool FindTilePosition(ShipState shipState, Vector3 position2, int magnitude)
    {
        Vector3 newPos = shipState.Position;
        newPos.x += Mathf.Abs(shipState.Position.x - position2.x) / magnitude;
        newPos.z += Mathf.Abs(shipState.Position.z - position2.z) / magnitude;
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
}