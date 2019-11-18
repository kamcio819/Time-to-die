using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MissileController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rg;
    [SerializeField]
    private List<ParticleSystem> explosion;

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

        StartCoroutine(DelayDeactivateObject());
    }

    private IEnumerator DelayDeactivateObject()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.DORotateQuaternion(Quaternion.LookRotation(rg.velocity), 0.5f);
    }
}
