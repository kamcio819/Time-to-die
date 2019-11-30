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

    public void DamageShip(float damage)
    {
        shipDataController.health -= damage;
        healthBar.fillAmount = shipDataController.health / 100f;
        if (shipDataController.health <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
