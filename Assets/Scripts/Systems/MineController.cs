using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MineController : MonoBehaviour
{
    [SerializeField]
    protected int goodAmount = default;

    [SerializeField]
    private PlayerType playerType = default;

    [SerializeField]
    private SpriteRenderer ownershipSprite = default;

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
