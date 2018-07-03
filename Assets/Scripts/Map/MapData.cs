using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace MapSystem {

	#region HexTilesType
			public enum Type {
				SIMPLE,
				ROADCROSS,
				ROADANGLE,
				ROADFORK,
				ROADLINE,
				SEA,
				RIVER
			}
	#endregion

	public struct MapMatrix {

	}
	public class MapData: MonoBehaviour {
		
		#region MapConstraints

			public int mapWidth;

			public int mapHeight;

			[HideInInspector]
			public HexTile tilePrefab;
		#endregion

		[HideInInspector]
		public List<HexTile> playerMap;

		[HideInInspector]
		public List<HexTile> enemyMap;

		void Awake()	{
			playerMap = new List<HexTile>(mapWidth * mapHeight);
			enemyMap = new List<HexTile>(mapWidth * mapHeight);
			SetTilePrefab(Type.SEA);
		}

		public void SetTilePrefab(Type tileType) {
			switch(tileType) {
				case Type.SIMPLE:
					tilePrefab = Resources.Load<HexTile>("simpleTile");
					break;
				case Type.SEA:
					tilePrefab = Resources.Load<HexTile>("seaTile");
					break;
				case Type.ROADLINE:
					tilePrefab = Resources.Load<HexTile>("roadLineTile");
					break;
				case Type.ROADFORK:
					tilePrefab = Resources.Load<HexTile>("roadForkTile");
					break;
				case Type.ROADCROSS:
					tilePrefab = Resources.Load<HexTile>("roadCrossTile");
					break;
				case Type.ROADANGLE:
					tilePrefab = Resources.Load<HexTile>("roadAngleTile");
					break;
				case Type.RIVER:
					tilePrefab = Resources.Load<HexTile>("riverTile");
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
	}
}
