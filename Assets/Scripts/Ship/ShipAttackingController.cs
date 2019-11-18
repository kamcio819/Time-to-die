using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAttackingController : MonoBehaviour, ITurnable
{
    [SerializeField]
    private Rigidbody missile;

    [SerializeField]
    private ShipDataController shipDataController;

    private Vector3 position = new Vector3(0, 37.84f, -5.4f);
    private Vector3 rotation = new Vector3(-90, 0, 0);

    private void Awake()
    {
        TurnModuleSystem.AddCommand(this);
    }

    private void OnDestroy()
    {
        TurnModuleSystem.RemoveCommand(this);
    }

    public void AttackPosition(Vector3 point, float v)
    {
        shipDataController.attackPoints--;
        if (shipDataController.attackPoints >= 0)
        {
            missile.GetComponent<MissileController>().SetDamage(shipDataController.ShipData.ShipDataContainer.GetDamage());
            missile.gameObject.SetActive(true);
            missile.transform.SetParent(null);

            Vector3 dir = point - transform.position;
            float height = dir.y;
            dir.y = 0;
            float dist = dir.magnitude;
            float a = 50 * Mathf.Deg2Rad;
            dir.y = dist * Mathf.Tan(a);
            dist += height / Mathf.Tan(a);

            float velocity = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
            missile.velocity = velocity * dir.normalized;
        }
    }

    public void TurnFinishUnit()
    {
        missile.velocity = Vector3.zero;
        missile.gameObject.SetActive(false);
        missile.transform.SetParent(gameObject.transform);
        missile.transform.localPosition = position;
        missile.transform.localEulerAngles = rotation;
    }
}
