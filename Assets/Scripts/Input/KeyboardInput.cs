using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyboardInput : MonoBehaviour {

    public float zoomDelta;
    public float xDelta;
    public float zDelta;

	public void OnUpdate()
    {
        zoomDelta = Input.GetAxis("Mouse ScrollWheel");
        xDelta = Input.GetAxis("Horizontal");
        zDelta = Input.GetAxis("Vertical");
    }
}
