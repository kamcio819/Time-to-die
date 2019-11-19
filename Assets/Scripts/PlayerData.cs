using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/Data", order = 1)]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private float time;

    [SerializeField]
    private int shipsAmount;

    [SerializeField]
    private int shipsDestroyed;

    public float Time { get => time; }
    public int ShipsAmount { get => shipsAmount; }
    public int ShipsDestroyed { get => shipsDestroyed; }

    public void AddTime(int _amount) { time += _amount; }
    public void AddShipsAmount(int _amount) { shipsAmount += _amount; }
    public void AddShipsDestroyed(int _amount) { shipsDestroyed += _amount; }
}
