using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassRotator : MonoBehaviour {

    [SerializeField]
    private TurnModuleSystem turnModuleSystem;

    [SerializeField]
    private Image fill;

	[Range(5, 15)]
	public float roationSpeed = 10f;

	private void Awake ()
    {
		transform.rotation = Quaternion.identity;		
	}

    private void OnEnable()
    {
        turnModuleSystem.EndTrun += ResetTimer;    
    }

    private void OnDisable()
    {
        turnModuleSystem.EndTrun += ResetTimer;
    }

    private void Update ()
    {
		transform.RotateAround(transform.position, Vector3.back, roationSpeed * Time.deltaTime);
        fill.fillAmount += 0.0135f * Time.deltaTime;
        if (fill.fillAmount == 1)
        {
            fill.fillAmount = 0f;
            turnModuleSystem.EndTurn();
        }
	}

    public void ResetTimer()
    {
        fill.fillAmount = 0f;
        transform.localEulerAngles = new Vector3(0, 0, 0);
    }
}
