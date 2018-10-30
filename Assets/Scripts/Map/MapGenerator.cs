using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapSystem;
using System;

public class MapGenerator : MonoBehaviour {

	public event Action MapsGenerated;

	[SerializeField]
	MapData mapData;
	
	[SerializeField]
	private GameObject playerMap;

	[SerializeField]
	private GameObject enemyMap;
	
	[SerializeField]
	private ChangeMapController changeMapController;

	void Awake () {

		for (int z = 0, i = 0; z < mapData.mapHeight; z++) {
			for (int x = 0; x < mapData.mapWidth; x++) {
				CreateCell(x, z, i++, playerMap);
			}
		}

		for (int z = 0, i = 0; z < mapData.mapHeight; z++) {
			for (int x = 0; x < mapData.mapWidth; x++) {
				CreateCell(x, z, i++, enemyMap);
			}
		}
		MapsGenerated.Invoke();
	}
	
	void CreateCell (int x, int z, int i, GameObject map) {

		Vector3 position;
		position.x = (x + z * 0.5f - z / 2) * (HexMetrics.INNER_RADIUS * 4f);
		position.y = 0f;
		position.z = z * 0.5f;

		if(map.transform.name == "PlayerMap") {
			mapData.SetTilePrefab(x,z);
		}
		else if(map.transform.name == "EnemyMap") {
			mapData.ResetTilePrefab();
		}
		HexTile cell = Instantiate<HexTile>(mapData.tilePrefab);
		cell.transform.SetParent(map.transform, false);
		cell.transform.localPosition = position;
		mapData.AddCell(cell, i, map.transform.name);

		if(x * 2 == mapData.mapWidth && z * 2 == mapData.mapHeight) {
			cell.transform.name = map.transform.name + "CenterTile";
			if(map.transform.name == "PlayerMap") {
				changeMapController.SetPlayerCenterTile(cell.transform);
			}
			else if(map.transform.name == "EnemyMap") {
				changeMapController.SetEnemyCenterTile(cell.transform);
			}
		}
	}
}
