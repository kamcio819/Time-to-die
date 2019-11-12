using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAttackingController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody sphere;

    public void AttackPosition(Vector3 point, float v)
    {
        sphere.gameObject.SetActive(true);
        sphere.transform.SetParent(null);

        Vector3 dir = point - transform.position;
        float height = dir.y;
        dir.y = 0;
        float dist = dir.magnitude;
        float a = 50 * Mathf.Deg2Rad;
        dir.y = dist * Mathf.Tan(a);
        dist += height / Mathf.Tan(a);

        float velocity = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        sphere.velocity = velocity * dir.normalized; 
    }
}
