using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyboardInput : MonoBehaviour {

    public float zoomDelta;
    public float xDelta;
    public float zDelta;

    public float yDeltaShip;

	public void OnUpdate()
    {
        zoomDelta = Input.GetAxis("Mouse ScrollWheel");
        xDelta = Input.GetAxis("Horizontal");
        zDelta = Input.GetAxis("Vertical");
        ShipRotation();
    }

    private void ShipRotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            yDeltaShip = -40f;
        } else if (Input.GetKey(KeyCode.E))
        {
            yDeltaShip = 40f;
        } else
        {
            yDeltaShip = 0f;
        }
    }
}
