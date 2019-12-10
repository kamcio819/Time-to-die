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
            if (ShipInRange(position, shipModuleSystem.PlayerShips[i], range))
            {
                return true;
            }
        }
        return false;
    }

    private static bool ShipInRange(Vector3 position, GameObject ship, float range)
    {
        if(Mathf.Abs(position.x - ship.transform.position.x) <= range && Mathf.Abs(position.z - ship.transform.position.z) <= range)
        {
            return true;
        }
        return false;
    }

    public static void AITryToMove(ShipState shipState)
    {
        GameObject shipToMove = null;
        int distance;

        for (int i = 0; i < shipModuleSystem.PlayerShips.Count; ++i)
        {
            if (ShipInRange(shipState.position, shipModuleSystem.PlayerShips[i], shipState.shipData.ShipDataContainer.GetMovementRange()))
            {
                shipToMove = shipModuleSystem.PlayerShips[i];
                distance = (int)(shipState.position - shipToMove.transform.position).magnitude;
                if (FindTilePosition(shipState, shipToMove.transform.position, distance/distance))
                {
                    shipState.shipDistance = distance;
                    break;
                }
                continue;
            }
        }

        shipToMove = shipModuleSystem.PlayerShips[UnityEngine.Random.Range(0, shipModuleSystem.PlayerShips.Count)];
        distance = (int)(shipState.position - shipToMove.transform.position).magnitude;
        if (FindTilePosition(shipState, shipToMove.transform.position, distance))
        {
            shipState.shipDistance = distance;
        }
    }

    private static bool FindTilePosition(ShipState shipState, Vector3 position2, int magnitude)
    {
        Vector3 newPos = shipState.position;
        newPos.x += Mathf.Abs(shipState.position.x - position2.x) / magnitude;
        newPos.z += Mathf.Abs(shipState.position.z - position2.z) / magnitude;
        for(int i = 0; i < seaTiles.Count; ++i)
        {
            if(CheckTilePos(newPos, seaTiles[i].transform.position))
            {
                shipState.position = seaTiles[i].transform.position;
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