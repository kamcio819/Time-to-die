using UnityEngine;
using System.Collections;
using UnityEditor;

public class BattleShipDataMaker {
    [MenuItem("Tools/Create New Ship %#a")]
    public static void CreateMyAsset()
    {
        BattleShipData asset = ScriptableObject.CreateInstance<BattleShipData>();

        AssetDatabase.CreateAsset(asset, "Assets/Prefabs/Ships/ShipsData/NewShipData.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}