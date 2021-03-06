﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCameraHandler : MonoBehaviour
{
    [SerializeField]
    private ShipModuleSystem shipModuleSystem = default;

    [SerializeField]
    private MaterialsModuleSystem materialsModuleSystem = default;

    [SerializeField]
    private CameraController cameraController = default;

    private Queue<ICommand> commandBuffer;

    private void OnEnable()
    {
        shipModuleSystem.ShipConstructed += SubscribeCameraMovement;
        materialsModuleSystem.MineConstructed += SubscribeCameraMovement;
        AIGameTreeProcesserModule.GameTreeAction += SubscribeCameraMovement;
    }

    private void OnDisable()
    {
        shipModuleSystem.ShipConstructed -= SubscribeCameraMovement;
        materialsModuleSystem.MineConstructed -= SubscribeCameraMovement;
        AIGameTreeProcesserModule.GameTreeAction -= SubscribeCameraMovement;
    }

    public void ProcessEvents()
    {
        StartCoroutine(ExecuteCommands());   
    }

    private IEnumerator ExecuteCommands()
    {
        for (int i = 0; i < commandBuffer.Count; ++i)
        {
            ICommand command = commandBuffer.Dequeue();
            command.Execute();
            yield return new WaitForSeconds(2.75f);
        }
    }

    public void Initialize()
    {
        commandBuffer = new Queue<ICommand>();
    }

    private void AddCommand(ICommand command)
    {
        commandBuffer.Enqueue(command);
    }

    private void SubscribeCameraMovement(Vector3 obj)
    {
        ICommand cameraFollowerCommand = new AIEventCameraFollower(cameraController, obj);
        AddCommand(cameraFollowerCommand);
    }

}
