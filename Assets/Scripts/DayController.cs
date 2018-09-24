using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayController : MonoBehaviour {

	private bool lightOpen = true;

	public void Toggle() {
		lightOpen = !lightOpen;
		GetComponent<Light>().intensity = lightOpen ? 0.82f : 0;
	}

	public bool isDay() {
		return lightOpen;
	}

	public bool isNight() {
		return !lightOpen;
	}
}
