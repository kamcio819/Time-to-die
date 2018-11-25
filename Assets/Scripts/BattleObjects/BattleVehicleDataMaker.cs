using UnityEngine;
using System.Collections;
using UnityEditor;

public class BattleVehicleDataMaker {
    [MenuItem("Tools/Create New Ship %#a")]
    public static void CreateShip()
    {
        BattleShipData asset = ScriptableObject.CreateInstance<BattleShipData>();

        AssetDatabase.CreateAsset(asset, "Assets/Prefabs/Ships/ShipsData/NewShipData.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

    [MenuItem("Tools/Create New Vehicle %#b")]
    public static void CreateVehicle()
    {
        BattleVehicleData asset = ScriptableObject.CreateInstance<BattleVehicleData>();

        AssetDatabase.CreateAsset(asset, "Assets/Prefabs/Vehicles/VehicleData/NewVehicleData.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}