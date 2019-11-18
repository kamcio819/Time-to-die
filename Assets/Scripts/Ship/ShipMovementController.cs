using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementController : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0.1f, 0f);

    [SerializeField]
    private ShipDataController shipDataController;

    public void MoveToPosition(Vector3 position, float duration)
    {
        shipDataController.movePoints--;
        if (shipDataController.movePoints >= 0)
        {
            Vector3 dir = position - transform.position;
            dir.y = 0;
            transform.DORotateQuaternion(Quaternion.LookRotation(dir), duration);
            transform.DOMove(position + offset, duration);
        }
    }
}
