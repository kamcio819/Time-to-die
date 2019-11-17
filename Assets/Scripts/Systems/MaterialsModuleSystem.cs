using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsModuleSystem : ITEModuleSystem
{
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

    [SerializeField]
    private MaterialsData materialsData = default;

    [SerializeField]
    private MineModuleFactory mineModuleFactory = default;

    private MineButton[] mineButtons;

    [SerializeField]
    private List<GameObject> mines = default;

    [SerializeField]
    private ObjectPlacer minePlacer;

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
        mines.Add(mineModuleFactory.ConstructShip(obj));
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
}
