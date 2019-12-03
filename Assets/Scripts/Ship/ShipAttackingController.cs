using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShipAttackingController : MonoBehaviour, ITurnable
{
    [SerializeField]
    private Rigidbody missile = default;

    [SerializeField]
    private ShipDataController shipDataController = default;

    [Range(20, 70)]
    public float angle = 70f;

    [SerializeField]
    private Vector3 beginPosition = new Vector3(0,0f, -5.4f);
    private Vector3 rotation = new Vector3(-90, 0, 0);

    private void Awake()
    {
        TurnModuleSystem.AddCommand(this);
    }

    private void OnDestroy()
    {
        TurnModuleSystem.RemoveCommand(this);
    }

    public bool AttackPosition(RaycastHit hit, Vector3 offset)
    {
        HexTile hexTile = hit.transform.GetComponent<HexTile>();
        if (hexTile)
        {
            if (HexInRange(hexTile, shipDataController.ShipData.ShipDataContainer.GetAttackRange()))
            {
                AttackPosition(hexTile.transform.position + offset, 1f);
                return true;
            }
        }
        return false;
    }

    private bool HexInRange(HexTile hexTile, float range)
    {
        if (Mathf.Abs(hexTile.transform.position.x - transform.position.x) <= range && Mathf.Abs(hexTile.transform.position.z - transform.position.z) <= range)
        {
            return true;
        }
        return false;
    }

    public void AttackPosition(Vector3 point, float speed)
    {
        shipDataController.attackPoints--;
        if (shipDataController.attackPoints >= 0)
        {
            StartCoroutine(LaunchMissile(point, speed));
        }
    }

    private IEnumerator LaunchMissile(Vector3 point, float speed)
    {
        Vector3 targetXZPos = new Vector3(point.x, 0.0f, point.z);
        transform.DOLookAt(targetXZPos, speed);

        yield return new WaitForSeconds(speed);

        SetMissile();
        missile.GetComponent<MissileController>().LaunchMissile(point, speed, angle);
    }

    private void SetMissile()
    {
        missile.GetComponent<MissileController>().SetDamage(shipDataController.ShipData.ShipDataContainer.GetDamage());
        missile.gameObject.SetActive(true);
        missile.transform.SetParent(null);
    }

    public void TurnFinishUnit()
    {
        missile.velocity = Vector3.zero;
        missile.gameObject.SetActive(false);
        missile.transform.SetParent(gameObject.transform);
        missile.transform.localPosition = beginPosition;
        missile.transform.localEulerAngles = rotation;
    }
}
