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
    [SerializeField]
    private MaterialsData materialsData = default;

    [SerializeField]
    private MineModuleFactory mineModuleFactory = default;

    private MineButton[] mineButtons;

    [SerializeField]
    private List<GameObject> mines = default;

    [SerializeField]
    private ObjectPlacer minePlacer;

    public MaterialsData MatData { get => materialsData; }

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
        mines.Add(mineModuleFactory.ConstructMine(obj));
        minePlacer.SetCurentObj(mines[mines.Count - 1]);
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

    public override void Execute()
    {
        for(int i = 0; i < mines.Count; ++i)
        {
            UpdateMaterials(mines[i]);
        }
    }

    private void UpdateMaterials(GameObject mine)
    {
        var specificMine = mine.GetComponent<MineController>();
        specificMine.ProduceMaterial(ref materialsData);
    }
}
