using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


#region ShipType
	public enum BattleVehicleLength {
		TILE1
	}

	public enum BattleVehicleType {
		BOMBER

	}

#endregion


[CreateAssetMenu(fileName = "Data", menuName = "Inventory/List", order = 1)]
public class BattleVehicleData : ScriptableObject {
    [ContextMenuItem("Reset", "ResetVehicleName")]
	 [TextArea]
	 public string objectName;
	 [Header("Stats")]
	 [Range(0, 100)]
    public float hp;
	 [Range(0,500)]
	 public float maxDamage;
	 [Header("Battle Vehicle Type")]
	 public BattleVehicleType battleVehicleData; 
	 public BattleVehicleLength battleVehicleLength;

	 public void ResetVehicleName() {
		 objectName = "";
	 }
}


