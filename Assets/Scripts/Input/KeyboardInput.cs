using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyboardInput : MonoBehaviour {

    public float ZoomDelta;
    public float XDelta;
    public float ZDelta;

    public float YDeltaShip;

	public void OnUpdate()
    {
        GetKeyboardInput();
        ObjectRotation();
    }

    private void GetKeyboardInput()
    {
        ZoomDelta = Input.GetAxis("Mouse ScrollWheel");
        XDelta = Input.GetAxis("Horizontal");
        ZDelta = Input.GetAxis("Vertical");
    }

    private void ObjectRotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            YDeltaShip = -40f;
        } 
        else if (Input.GetKey(KeyCode.E))
        {
            YDeltaShip = 40f;
        } 
        else
        {
            YDeltaShip = 0f;
        }
    }
}
