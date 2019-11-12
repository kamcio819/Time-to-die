using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementController : MonoBehaviour
{
    public void SetPosition(Vector3 position, float duration)
    {
        Vector3 dir = position - transform.position;
        dir.y = 0;
        transform.DORotateQuaternion(Quaternion.LookRotation(dir), duration);
        transform.DOMove(position, duration);
    }
}
