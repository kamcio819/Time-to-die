using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MapSystem;

[System.Serializable]
	public class HexTile : MonoBehaviour {

		#region HexTilesInfo
			public float movementPoints;
		
			public int tileWidth;

			public int tileHeight;

			public bool isWalkable;

			public Type tileType;

			public AvailableToPlaceOn availableToPlaceOn;
    #endregion

}

