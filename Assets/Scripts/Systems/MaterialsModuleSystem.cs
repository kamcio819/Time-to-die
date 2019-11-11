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
    private MaterialsData materialsData; 

    public override void Exit()
    {
    }

    public override void Initialize()
    {
    }

    public override void Tick()
    {
    }
}
