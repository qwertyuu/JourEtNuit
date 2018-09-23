using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggle : MonoBehaviour {
	
	[SerializeField]
	public DayController daylight;

	void OnTriggerEnter2D() {
		daylight.Toggle();
		Destroy(gameObject);
	}
}
