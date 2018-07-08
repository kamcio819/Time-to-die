using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace MapSystem {

	#region HexTilesType
			public enum Type {
				SIMPLE,
				SIMPLENVIRO,
				SEA,
				SEAENVIRO
			}
	#endregion

	#region Clickable
	public enum AvailableToPlaceOn {
		YES,
		NO
	}
	#endregion
	
	public class MapData: MonoBehaviour {
		
		#region MapConstraints

			public int mapWidth;

			public int mapHeight;

			private int[][] mapMatrix;

			[HideInInspector]
			public HexTile tilePrefab;
		#endregion

		[HideInInspector]
		public List<HexTile> playerMap;

		[HideInInspector]
		public List<HexTile> enemyMap;

		void Awake() {
			SetupTilesArray();
			GenerateMapMatrix();
			playerMap = new List<HexTile>(mapWidth * mapHeight);
			enemyMap = new List<HexTile>(mapWidth * mapHeight);
		}

		void SetupTilesArray () {	
        mapMatrix = new int[mapWidth][];
        for (int i = 0; i < mapMatrix.Length; i++) {
            mapMatrix[i] = new int[mapHeight];
        }
  		}

      private void GenerateMapMatrix() {
			for(int i = 0; i < mapWidth; ++i) {
				for(int z = 0; z < mapHeight; ++z) {
					if(UnityEngine.Random.Range(0,15) == 1) {
						mapMatrix[i][z] = 1;
						continue;
					}
					if(UnityEngine.Random.Range(0,15) == 2) {
						mapMatrix[i][z] = 2;
						continue;
					}
					if(UnityEngine.Random.Range(0,15) == 3) {
						mapMatrix[i][z] = 3;
						continue;
					}
					mapMatrix[i][z] = 0;
				}
			}
      }

      public void SetTilePrefab(int x, int z) {
			switch(mapMatrix[x][z]) {
				case 3:
					tilePrefab = Resources.Load<HexTile>("SimpleTile");
					break;
				case 0:
					tilePrefab = Resources.Load<HexTile>("SeaTile");
					break;
				case 2:
					tilePrefab = Resources.Load<HexTile>("EnviroSeaTile" + UnityEngine.Random.Range(1,2).ToString());
					break;
				case 1:
					tilePrefab = Resources.Load<HexTile>("EnviroSimpleTile" + UnityEngine.Random.Range(1,2).ToString());
					break;
			}
			
		}

		public void AddCell(HexTile cellToAdd, int index, string type) {
			switch(type) {
				case "enemyMap":
					enemyMap.Insert(index, cellToAdd);
					break;
				case "playerMap":
					playerMap.Insert(index, cellToAdd);
					break;
			}
		}

		public void ResetTilePrefab() {
			tilePrefab = Resources.Load<HexTile>("SeaTile");
		}
	}
}
