using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class MissileController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rg;
    [SerializeField]
    private List<ParticleSystem> explosion;
    [SerializeField]
    private List<Collider> colliders;

    private float damage;

    public float Damage { get => damage; }

    public void SetDamage(float _damage)
    {
        damage = _damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < explosion.Count; ++i)
        {
            explosion[i].Play();
        }
        DamageShip(collision);
        ToggleColliders(false);
        StartCoroutine(DelayDeactivateObject());
    }

    private void DamageShip(Collision collision)
    {
        var shipDamager = collision.transform.GetComponent<ShipDamageController>();
        if (shipDamager)
        {
            shipDamager.DamageShip(damage);
        }
    }

    private void ToggleColliders(bool flag)
    {
        for (int i = 0; i < colliders.Count; ++i)
        {
            colliders[i].enabled = flag;
        }
    }

    private IEnumerator DelayDeactivateObject()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        ToggleColliders(true);
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(rg.velocity);
    }

    public void LaunchMissile(Vector3 point, float speed, float angle)
    {
        Vector3 projectileXZPos = new Vector3(transform.position.x, 0.0f, transform.position.z);

        float R, G, tanAlpha, H;
        CalculateProjectileMotion(point, projectileXZPos, point, out R, out G, out tanAlpha, out H, angle);

        rg.velocity = SetVelocity(R, G, tanAlpha, H);
    }

    private Vector3 SetVelocity(float R, float G, float tanAlpha, float H)
    {
        float Vz = Mathf.Sqrt(G * R * R / (2.0f * (H - R * tanAlpha)));
        float Vy = tanAlpha * Vz;

        Vector3 localVelocity = new Vector3(0f, Vy, Vz);
        Vector3 globalVelocity = transform.TransformDirection(localVelocity);
        globalVelocity.x *= -1f;
        globalVelocity.z *= -1f;
        return globalVelocity;
    }

    private void CalculateProjectileMotion(Vector3 point, Vector3 projectileXZPos, Vector3 targetXZPos, out float R, out float G, out float tanAlpha, out float H, float angle)
    {
        R = Vector3.Distance(projectileXZPos, targetXZPos);
        G = Physics.gravity.y;
        tanAlpha = Mathf.Tan(angle * Mathf.Deg2Rad);
        H = point.y - transform.position.y;
    }

}
