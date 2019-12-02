using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MineController : MonoBehaviour
{
    [SerializeField]
    protected int goodAmount;

    [SerializeField]
    private PlayerType playerType;

    [SerializeField]
    private SpriteRenderer ownershipSprite;

    public PlayerType PlayerType { get => playerType; }

    public abstract int ProduceMaterial(MaterialsData matData);

    public void SetOwner(PlayerType _playerType)
    {
        playerType = _playerType;

        if (playerType == PlayerType.CPU)
            ownershipSprite.color = Color.red;
        else
            ownershipSprite.color = Color.yellow;
    }
}
