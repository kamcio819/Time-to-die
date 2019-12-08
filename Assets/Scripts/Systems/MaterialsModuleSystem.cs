using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MaterialsData
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
    private EventModuleSystem eventModuleSystem = default;

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

    public Dictionary<PlayerType, MaterialsData> MaterialsData = new Dictionary<PlayerType, MaterialsData>();

    public List<GameObject> PlayerMines { get => playerMines; }
    public List<GameObject> EnemyMines { get => enemyMines; }

    public Action<Vector3> MineConstructed;

    protected override void Awake()
    {
        base.Awake();
    }

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
        if(ResourcesCheckerModuleSystem.CheckResources(obj, true, PlayerType.PLAYER))
        {
            GameObject mine = mineModuleFactory.ConstructMine(obj, PlayerType.PLAYER);
            playerMines.Add(mine);
            allMines.Add(mine);
            minePlacer.SetCurentObj(playerMines[playerMines.Count - 1]);
        }
        else
        {
            eventModuleSystem.Notify<EventUIBinder>("Not enough founds to create MINE: " + obj.ToString());
        }
    }

    public void InstantiateCPUMine(MineType obj)
    {
        if (ResourcesCheckerModuleSystem.CheckResources(obj, true, PlayerType.CPU))
        {
            GameObject mine = mineModuleFactory.ConstructMine(obj, PlayerType.CPU);
            minePlacer.PlaceCPUMine(mine);
            enemyMines.Add(mine);
            allMines.Add(mine);
            MineConstructed?.Invoke(mine.transform.position);
        }
    }

    public void InstantiateCPUMine(int type)
    {
        if (ResourcesCheckerModuleSystem.CheckResources((MineType)type, true, PlayerType.CPU))
        {
            GameObject mine = mineModuleFactory.ConstructMine((MineType)type, PlayerType.CPU);
            minePlacer.PlaceCPUMine(mine);
            enemyMines.Add(mine);
            allMines.Add(mine);
            MineConstructed?.Invoke(mine.transform.position);
        }
    }

    public override void Exit()
    {
    }

    public override void Initialize()
    {
        mineButtons = FindObjectsOfType<MineButton>();

        MaterialsData.Add(PlayerType.CPU, enemyMaterialData);
        MaterialsData.Add(PlayerType.PLAYER, playerMaterialData);
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
            UpdateMaterials(playerMines[i], PlayerType.PLAYER);
        }
        for (int i = 0; i < enemyMines.Count; ++i)
        {
            UpdateMaterials(enemyMines[i], PlayerType.CPU);
        }
    }

    private void UpdateMaterials(GameObject mine, PlayerType playerType)
    {
        var specificMine = mine.GetComponent<MineController>();
        specificMine.ProduceMaterial(MaterialsData[playerType]);
    }

    public void RemoveResources(MaterialsData matData, Tuple<int, int, int> tuple)
    {
        matData.AddGold(-tuple.Item1);
        matData.AddOil(-tuple.Item2);
        matData.AddIron(-tuple.Item3);
    }

    public void AddLocalResources()
    {
        AddResources(PlayerType.PLAYER);
        AddResources(PlayerType.CPU);
    }

    private void AddResources(PlayerType playerType)
    {
        MaterialsData[playerType].AddGold(1);
        MaterialsData[playerType].AddOil(1);
        MaterialsData[playerType].AddIron(1);
    }
}
