using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField]
    private CursorInput cursorInput = default;

    [SerializeField]
    private KeyboardInput keyboardInput = default;

    [SerializeField]
    private Camera cam = default;

    [SerializeField]
    private LayerMask layerMask = default;

    [SerializeField]
    private MapModuleSystem mapModuleSystem = default;

    private GameObject currentObj;
    private Vector3 offset = new Vector3(0f, 0.1f, 0f);

    private float timer = 0f;
    public bool ShipPlacer = false;
    public bool BuildingPlacer = false;

    public void SetCurentObj(GameObject cs)
    {
        currentObj = cs;
    }

    public void OnUpdate()
    {
        if (currentObj)
        {
            timer += 0.15f;
            UpdatePosition();
            currentObj.transform.RotateAround(currentObj.transform.position, Vector3.up, keyboardInput.YDeltaShip * Time.deltaTime);
            if (timer > 0.5f && cursorInput.LeftMouseClicked && CorrectPosition())
            {
                timer = 0f;
                currentObj = null;
            }
        }
    }

    private bool CorrectPosition()
    {
        return true;
    }

    private void UpdatePosition()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(cursorInput.MousePosition);

        if (Physics.Raycast(ray, out hit, layerMask))
        {
            HexTile tile = hit.transform.GetComponent<HexTile>();
            if (tile)
            {
                PlaceObject(tile);
            }
        }
    }

    private void PlaceObject(HexTile tile)
    {
        if (ShipPlacer)
        {
            if (tile.tileType == MapSystem.Type.SEA 
                && tile.availableToPlaceOn == MapSystem.AvailableToPlaceOn.YES 
                && !ShipSideMapTilesX(tile.gameObject, PlayerType.PLAYER))
            {
                currentObj.transform.position = tile.transform.position + offset;
            }
        }
        if (BuildingPlacer)
        {
            if (tile.tileType == MapSystem.Type.SIMPLE 
                && tile.availableToPlaceOn == MapSystem.AvailableToPlaceOn.YES 
                && !MineSideMapTiles(tile.gameObject, PlayerType.PLAYER))
            {
                currentObj.transform.position = tile.transform.position + offset;
            }
        }
    }

    public void PlaceCPUShip(GameObject ship)
    {
        List<GameObject> seaTiles = mapModuleSystem.Tiles.FindAll(x => CanPlaceOnTile(x, MapSystem.Type.SEA));
        seaTiles.RemoveAll(x => ShipSideMapTilesX(x, PlayerType.CPU));
        ship.transform.position = seaTiles[UnityEngine.Random.Range(0, seaTiles.Count - 1)].transform.position + offset;
    }

    public void PlaceCPUMine(GameObject mine)
    {
        List<GameObject> simpleTiles = mapModuleSystem.Tiles.FindAll(x => CanPlaceOnTile(x, MapSystem.Type.SIMPLE));
        simpleTiles.RemoveAll(x => MineSideMapTiles(x, PlayerType.CPU));
        mine.transform.position = simpleTiles[UnityEngine.Random.Range(0, simpleTiles.Count - 1)].transform.position + offset;
    }

    private bool CanPlaceOnTile(GameObject x, MapSystem.Type type)
    {
        HexTile hexTile = x.GetComponent<HexTile>();
        if (hexTile)
        {
            if (hexTile.tileType == type && hexTile.availableToPlaceOn == MapSystem.AvailableToPlaceOn.YES)
            {
                return true;
            }
        }
        return false;
    }

    public void PlaceShipOnInitialPosition(GameObject ship, PlayerType playerType)
    {
        List<GameObject> seaTiles = mapModuleSystem.Tiles.FindAll(x => CanPlaceOnTile(x, MapSystem.Type.SEA));
        seaTiles.RemoveAll(x => ShipSideMapTilesX(x, playerType));
        seaTiles.RemoveAll(x => ShipSideMapTilesZ(x));
        ship.transform.position = seaTiles[UnityEngine.Random.Range(0, seaTiles.Count - 1)].transform.position + offset;
    }

    private bool ShipSideMapTilesX(GameObject tile, PlayerType playerType)
    {
        if (tile.transform.position.x > 8f && playerType == PlayerType.PLAYER)
        {
            return true;
        }

        if(tile.transform.position.x < 16f && playerType == PlayerType.CPU)
        {
            return true;
        }

        return false;
    }

    private bool ShipSideMapTilesZ(GameObject tile)
    {
        if (tile.transform.position.z > 18f || tile.transform.position.z < 3f)
            return true;

        return false;
    }

    private bool MineSideMapTiles(GameObject tile, PlayerType playerType)
    {
        if (tile.transform.position.x > 10f && playerType == PlayerType.PLAYER)
        {
            return true;
        }

        if (tile.transform.position.x < 14f && playerType == PlayerType.CPU)
        {
            return true;
        }

        return false;
    }
}
