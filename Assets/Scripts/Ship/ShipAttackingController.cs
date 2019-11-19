using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShipAttackingController : MonoBehaviour, ITurnable
{
    [SerializeField]
    private Rigidbody missile;

    [SerializeField]
    private ShipDataController shipDataController;

    [Range(20, 70)]
    public float angle = 40f;

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
        Vector3 projectileXZPos = new Vector3(transform.position.x, 0.0f, transform.position.z);
        Vector3 targetXZPos = new Vector3(point.x, 0.0f, point.z);

        transform.DOLookAt(targetXZPos, speed);

        yield return new WaitForSeconds(speed);
        SetMissile();

        float R, G, tanAlpha, H;
        CalculateProjectileMotion(point, projectileXZPos, targetXZPos, out R, out G, out tanAlpha, out H);

        Vector3 globalVelocity = SetVelocity(R, G, tanAlpha, H);

        missile.velocity = globalVelocity;
    }

    private Vector3 SetVelocity(float R, float G, float tanAlpha, float H)
    {
        float Vz = Mathf.Sqrt(G * R * R / (2.0f * (H - R * tanAlpha)));
        float Vy = tanAlpha * Vz;

        Vector3 localVelocity = new Vector3(0f, Vy, Vz);
        Vector3 globalVelocity = transform.TransformDirection(localVelocity);
        return globalVelocity;
    }

    private void CalculateProjectileMotion(Vector3 point, Vector3 projectileXZPos, Vector3 targetXZPos, out float R, out float G, out float tanAlpha, out float H)
    {
        R = Vector3.Distance(projectileXZPos, targetXZPos);
        G = Physics.gravity.y;
        tanAlpha = Mathf.Tan(angle * Mathf.Deg2Rad);
        H = point.y - transform.position.y;
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
        missile.transform.localPosition = position;
        missile.transform.localEulerAngles = rotation;
    }
}
