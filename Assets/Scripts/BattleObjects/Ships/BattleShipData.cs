using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


#region ShipType
	public enum BattleShipLength {
		TILE1,
		TILE2,
		TILE3,
		TILE4,
		TILE6,
		TILE7,
		TILE8
	}

	public enum BattleShipType {
		SUPPORT_CARRIER,
		DESTROYER,
		CRUISER,
		BATTLESHIP,
		MINESWEEPER,
		HEALER,
		SUBMARINE,
		BOMBER

	}

#endregion


[CreateAssetMenu(fileName = "Data", menuName = "Inventory/List", order = 1)]
public class BattleShipData : ScriptableObject {
    [ContextMenuItem("Reset", "ResetShipName")]
	 [TextArea]
	 public string objectName;
	 [Header("Stats")]
	 [Range(0, 100)]
    public float hp;
	 [Range(0,500)]
	 public float maxDamage;
	 [Header("Ship Type")]
	 public BattleShipType battleshipType; 
	 public BattleShipLength battleshipLength;

	 public void ResetShipName() {
		 objectName = "";
	 }
}


