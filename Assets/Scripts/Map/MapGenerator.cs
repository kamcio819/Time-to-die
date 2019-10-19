using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapSystem;
using System;

public class MapGenerator : MonoBehaviour {

	public Action MapsGenerated;

	[SerializeField]
	MapData mapData;

    [SerializeField]
    private GameObject mapObject;
	
	[SerializeField]
	private ChangeMapController changeMapController;

    private Transform centerTile;

    public Transform CenterTile { get => centerTile; }
    public GameObject MapObject { get => mapObject; }

    void Awake () {

		for (int z = 0, i = 0; z < mapData.mapHeight; z++) {
			for (int x = 0; x < mapData.mapWidth; x++) {
				CreateCell(x, z, i++, MapObject);
			}
		}
		
		if(MapsGenerated != null) {
			MapsGenerated();
		}	
	}
	
	void CreateCell (int x, int z, int i, GameObject map) {

		Vector3 position;
		position.x = (x + z * 0.5f - z / 2) * (HexMetrics.INNER_RADIUS * 4f);
		position.y = 0f;
		position.z = z * 0.5f;

		mapData.SetTilePrefab(x,z);

		HexTile cell = Instantiate<HexTile>(mapData.tilePrefab);
		cell.transform.SetParent(map.transform, false);
		cell.transform.localPosition = position;
		mapData.AddCell(cell, i, map.transform.name);

		if(x * 2 == mapData.mapWidth && z * 2 == mapData.mapHeight) {
            centerTile = cell.transform;
		}
	}
}
