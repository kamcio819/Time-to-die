using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEventCameraFollower : ICommand
{
    private CameraController cameraController;
    private Vector3 cameraPosition;

    public AIEventCameraFollower(CameraController _cameraController, Vector3 _cameraPosition)
    {
        cameraController = _cameraController;
        cameraPosition = _cameraPosition;
    }

    public void Execute()
    {
        cameraController.SetCameraPosition(cameraPosition);
    }
}
