using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipDamageController : MonoBehaviour
{
    [SerializeField]
    private ShipDataController shipDataController = default;

    [SerializeField]
    private Image healthBar = default;

    [SerializeField]
    private MeshRenderer meshRenderer = default;

    private Material[] objectMaterials;
    private Color color;
    private WaitForSeconds wfs;

    private void Awake()
    {
        objectMaterials = meshRenderer.materials;
        wfs = new WaitForSeconds(0.05f);
    }

    public void DamageShip(float damage)
    {
        shipDataController.health -= damage;
        healthBar.fillAmount = shipDataController.health / 100f;
        StartCoroutine(GiveDamageVisual());
        if (shipDataController.health <= 0f)
        {
            Destroy(this.gameObject);
        }
    }

    private IEnumerator GiveDamageVisual()
    {
        for (float i = 0f; i < 1f; i += Time.deltaTime)
        {
            ToggleMaterials(0f);
            yield return wfs;
            ToggleMaterials(1f);
            yield return wfs;
        }
        ToggleMaterials(1f);
    }

    private void ToggleMaterials(float val)
    {
        for (int j = 0; j < objectMaterials.Length; ++j)
        {
            color = objectMaterials[j].color;
            color.a = val;
            objectMaterials[j].color = color;
        }
    }
}
