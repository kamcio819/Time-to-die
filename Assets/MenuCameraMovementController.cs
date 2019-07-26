using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Camera))]
public class MenuCameraMovementController : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private Transform centerOfRotation;

    [SerializeField]
    [Range(5, 25f)]
    private float angleRotation = 20f;

    [SerializeField]
    [Range(1,5)]
    private float speedModifier = 2f;

    private Vector3 centerOfRotationPosition;

    private void Awake() {
        centerOfRotationPosition = centerOfRotation.position;
    }

    private void Update() {
        cameraTransform.RotateAround(centerOfRotationPosition, Vector3.up, angleRotation * Time.deltaTime * speedModifier);
    }
}
