using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDamageController : MonoBehaviour
{
    [SerializeField]
    private ShipDataController shipDataController;

    public void OnTriggerEnter(Collider other)
    {
        shipDataController.health -= other.GetComponent<MissileController>().Damage;
        if (shipDataController.health <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
