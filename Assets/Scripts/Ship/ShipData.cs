using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ShipData", menuName = "Ships/Data", order = 1)]
[PreferBinarySerialization]
public class ShipData :  ScriptableObject
{
    [System.Serializable]
    public struct Data
    {
        [SerializeField]
        [Range(0, 200f)]
        float maxHealth;

        [SerializeField]
        [Range(0, 50f)]
        float damage;

        [SerializeField]
        [Range(1, 4)]
        int moveRange;

        [SerializeField]
        [Range(0, 8f)]
        float shootingRange;

        public float GetDamage() { return damage; }
        public int GetMovementRange() { return moveRange; }
        public float GetAttackRange() { return shootingRange; }
        public float GetMaxHealth() { return maxHealth; }

        public void AddDamage(float _damage) { damage += _damage; }
        public void AddMovementRange(int _moveRange) { moveRange += _moveRange; }
        public void AddAttackRange(float _shootingRange) { shootingRange += _shootingRange; }
        public void AddMaxHealth(float _maxHealth) { maxHealth += _maxHealth; }
    }


    [SerializeField]
    public Data ShipDataContainer;

    [SerializeField]
    private ParticleSystem damageParticle;

}
