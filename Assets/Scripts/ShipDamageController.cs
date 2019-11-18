using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDamageController : MonoBehaviour
{
    [SerializeField]
    private ShipDataController shipDataController;

    public void OnCollisionEnter(Collision other)
    {
        shipDataController.health -= other.transform.GetComponent<MissileController>().Damage;
        if (shipDataController.health <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
