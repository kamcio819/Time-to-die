using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class KeyboardInput : MonoBehaviour {

	public event Action ChangeMap;
	void Update () {
		if(Input.GetKey(KeyCode.K)) {
			ChangeMap.Invoke();
		}
	}
}
