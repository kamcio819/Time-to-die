using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShipOwnershipController : MonoBehaviour
{
    [SerializeField]
    private Material enemyMaterial = default;

    [SerializeField]
    private Material playerMaterial = default;

    [SerializeField]
    private MeshRenderer meshRenderer = default;

    private List<Material> materials;
    private Material[] mats;

    private void Awake()
    {
        materials = meshRenderer.materials.ToList();
    }

    public void SetMaterial(PlayerType playerType)
    {
        switch (playerType)
        {
            case PlayerType.CPU:
                ChangeMaterial(enemyMaterial);
                break;
            case PlayerType.PLAYER:
                ChangeMaterial(playerMaterial);
                break;
        }
    }

    private void ChangeMaterial(Material mat)
    {
        int index = materials.IndexOf(materials.Find(x => x.name.Equals("Green (Instance)")));
        mats = meshRenderer.materials;
        mats[index] = mat;
        meshRenderer.materials = mats;
    }
}
