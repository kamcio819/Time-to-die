using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


#region ShipType
	public enum BattleShipType {
		TILE1,
		TILE2,
		TILE3,
		TILE4,
		TILE6,
		TILE7,
		TILE8
	}

#endregion

[System.Serializable]
public struct BattleShipData {

	[SerializeField]
	private BattleShipType typeOfShip;
} 


