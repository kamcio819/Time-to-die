using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipDamageController : MonoBehaviour
{
    [SerializeField]
    private ShipDataController shipDataController;

    [SerializeField]
    private Image healthBar;

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
