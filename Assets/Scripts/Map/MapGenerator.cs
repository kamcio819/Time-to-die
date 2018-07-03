using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MapSystem;
public class MapGenerator : MonoBehaviour {

	MapData mapData;
	
	GameObject tileMapParrent;
	void Awake () {

		mapData = GetComponent<MapData>();
		tileMapParrent = GameObject.Find("TileMap");

		for (int z = 0, i = 0; z < mapData.mapHeight; z++) {
			for (int x = 0; x < mapData.mapWidth; x++) {
				CreateCell(x, z, i++);
			}
		}
	}
	
	void CreateCell (int x, int z, int i) {
		Vector3 position;
		position.x = (x + z * 0.5f - z / 2) * (HexMetrics.INNER_RADIUS * 4f);
		position.y = 0f;
		position.z = z * 0.5f;

		HexTile cell = Instantiate<HexTile>(mapData.tilePrefab);
		mapData.AddCell(cell, i);
		cell.transform.SetParent(tileMapParrent.transform, false);
		cell.transform.localPosition = position;
	}
}
