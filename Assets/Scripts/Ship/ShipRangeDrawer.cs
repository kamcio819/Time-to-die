using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRangeDrawer : MonoBehaviour
{
    [SerializeField]
    private ShipDataController shipDataController;

    [SerializeField]
    private ShipTileController shipTileController;

    public void DrawMovementRange(bool flag)
    {
        Collider[] tiles = Physics.OverlapSphere(transform.position, shipDataController.ShipData.ShipDataContainer.GetMovementRange());
        for (int i = 0; i < tiles.Length; ++i)
        {
            TileController tileController = tiles[i].GetComponent<TileController>();
            HexTile hexTile = tiles[i].GetComponent<HexTile>();
            if (tileController && hexTile && hexTile.tileType == MapSystem.Type.SEA && shipTileController.CheckForTileAvailability(hexTile))
            {
                if (flag)
                    tileController.ChangeColorOfTile(Color.gray);
                else
                    tileController.ResetTileColor();
            }

        }
    }

    public void DrawAttackRange(bool flag)
    {
        Collider[] tiles = Physics.OverlapSphere(transform.position, shipDataController.ShipData.ShipDataContainer.GetAttackRange());
        for (int i = 0; i < tiles.Length; ++i)
        {
            TileController tileController = tiles[i].GetComponent<TileController>();
            if (tileController)
            {
                if (flag)
                    tileController.ChangeColorOfTile(Color.yellow);
                else
                    tileController.ResetTileColor();
            }
        }
    }

}
