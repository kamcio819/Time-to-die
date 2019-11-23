using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MaterialsData
{
    [SerializeField]
    [Range(0, 100)]
    private int gold;

    [SerializeField]
    [Range(0, 100)]
    private int oil;

    [SerializeField]
    [Range(0, 100)]
    private int iron;

    public int GetGold() { return gold; }
    public int GetOil() { return oil; }
    public int GetIron() { return iron; }

    public void AddGold(int count) { gold += count; }
    public void AddOil(int count) { oil += count; }
    public void AddIron(int count) { iron += count; }
}

public class MaterialsModuleSystem : ITEModuleSystem
{
    [Header("Materials Data")]
    [SerializeField]
    private MaterialsData playerMaterialData = default;

    [SerializeField]
    private MaterialsData enemyMaterialData = default;

    [Header("Controllers")]
    [Space(20)]
    [SerializeField]
    private MineModuleFactory mineModuleFactory = default;

    [SerializeField]
    private ObjectPlacer minePlacer = default;

    private MineButton[] mineButtons;

    [Header("Holders")]
    [Space(20)]
    [SerializeField]
    private List<GameObject> playerMines = default;

    [SerializeField]
    private List<GameObject> allMines = default;

    [SerializeField]
    private List<GameObject> enemyMines = default;

    public MaterialsData PlayerMaterialData { get => playerMaterialData; }
    public MaterialsData EnemyMaterialData { get => enemyMaterialData; }

    private void OnEnable()
    {
        for (int i = 0; i < mineButtons.Length; ++i)
        {
            mineButtons[i].ButtonPressed += InstantiateMine;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < mineButtons.Length; ++i)
        {
            mineButtons[i].ButtonPressed -= InstantiateMine;
        }
    }

    private void InstantiateMine(MineType obj)
    {
        if(ResourcesCheckerModuleSystem.CheckResources(obj))
        {
            GameObject mine = mineModuleFactory.ConstructMine(obj, PlayerType.PLAYER);
            playerMines.Add(mine);
            allMines.Add(mine);
            minePlacer.SetCurentObj(playerMines[playerMines.Count - 1]);
        }   
    }

    public override void Exit()
    {
    }

    public override void Initialize()
    {
        mineButtons = FindObjectsOfType<MineButton>();
    }

    public override void Tick()
    {
        minePlacer.OnUpdate();
    }

    public override void TurnFinishUnit()
    {
        AddLocalResources();
        for (int i = 0; i < playerMines.Count; ++i)
        {
            UpdateMaterials(playerMines[i]);
        }
    }

    private void UpdateMaterials(GameObject mine)
    {
        var specificMine = mine.GetComponent<MineController>();
        specificMine.ProduceMaterial(ref playerMaterialData);
    }

    public void RemoveResources(Tuple<int, int, int> tuple)
    {
        playerMaterialData.AddGold(-tuple.Item1);
        playerMaterialData.AddOil(-tuple.Item2);
        playerMaterialData.AddIron(-tuple.Item3);
    }

    public void AddLocalResources()
    {
        playerMaterialData.AddGold(1);
        playerMaterialData.AddOil(1);
        playerMaterialData.AddIron(1);
    }
}
