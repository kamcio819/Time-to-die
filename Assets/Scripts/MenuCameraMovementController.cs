using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Camera))]
public class MenuCameraMovementController : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform = default;

    [SerializeField]
    private Transform centerOfRotation = default;

    [SerializeField]
    [Range(1, 10f)]
    private float angleRotation = 5f;

    [SerializeField]
    [Range(1,5)]
    private float speedModifier = 1f;

    private Vector3 centerOfRotationPosition;

    private void Awake() {
        centerOfRotationPosition = centerOfRotation.position;
    }

    private void Update() {
        cameraTransform.RotateAround(centerOfRotationPosition, Vector3.up, angleRotation * Time.deltaTime * speedModifier);
    }
}
