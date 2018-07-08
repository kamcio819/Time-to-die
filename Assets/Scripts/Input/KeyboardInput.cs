using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class KeyboardInput : MonoBehaviour {

	public event Action ChangeMap;
	void LateUpdate () {
		if(Input.GetKeyDown(KeyCode.K)) {
			ChangeMap.Invoke();
		}
	}
}
