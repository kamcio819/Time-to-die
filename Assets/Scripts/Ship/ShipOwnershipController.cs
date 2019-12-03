using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShipOwnershipController : MonoBehaviour
{
    [SerializeField]
    private Material enemyMaterial;

    [SerializeField]
    private Material playerMaterial;

    [SerializeField]
    private MeshRenderer meshRenderer;

    private List<Material> materials;

    private void Awake()
    {
        materials = meshRenderer.materials.ToList();
    }

    public void SetMaterial(PlayerType playerType)
    {
        int index;
        switch (playerType)
        {
            case PlayerType.CPU:
                index = materials.IndexOf(materials.Find(x=>x.name.Equals("Green (Instance)")));
                meshRenderer.materials[index] = enemyMaterial;
                break;
            case PlayerType.PLAYER:
                index = materials.IndexOf(materials.Find(x => x.name.Equals("Green (Instance)")));
                meshRenderer.materials[index] = playerMaterial;
                break;
        }
    }
}
