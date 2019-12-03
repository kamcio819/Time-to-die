using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTileController : MonoBehaviour
{
    public List<HexTile> OccupiedTiles = new List<HexTile>();

    private void OnTriggerEnter(Collider other)
    {
        HexTile hexTile = other.GetComponent<HexTile>();
        OccupiedTiles.Add(hexTile);
        if (hexTile)
        {
            hexTile.availableToPlaceOn = MapSystem.AvailableToPlaceOn.NO;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        HexTile hexTile = other.GetComponent<HexTile>();
        OccupiedTiles.Remove(hexTile);
        if (hexTile)
        {
            hexTile.availableToPlaceOn = MapSystem.AvailableToPlaceOn.YES;
        }
    }

    public bool CheckForTileAvailability(HexTile hexTile)
    {
        if (OccupiedTiles.Contains(hexTile))
        {
            return true;
        } else
        {
            if (hexTile.availableToPlaceOn == MapSystem.AvailableToPlaceOn.YES)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
