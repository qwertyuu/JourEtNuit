using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggle : MonoBehaviour {
	
	[SerializeField]
	public DayController daylight;
	[SerializeField]
	public GameObject timer;
	[SerializeField]
	public float tempsPourAppuyer = 2;

	private int nombreDeJoueursSurLeBouton = 0;
	private GameObject activeTimer;

	void DeleteTimer() {
		Destroy(activeTimer);
	}

	void NewTimer() {
		var t = Instantiate(timer, transform);
		t.transform.Translate(0, 1, 0);
		t.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
		
		t.GetComponent<Timer>().temps = tempsPourAppuyer;
		activeTimer = t;
	}

	void OnTriggerExit2D() {
		nombreDeJoueursSurLeBouton--;
		if (nombreDeJoueursSurLeBouton == 0) {
			DeleteTimer();
		}
	}

	void OnTriggerEnter2D() {
		if (nombreDeJoueursSurLeBouton == 0) {
			NewTimer();
		}
		nombreDeJoueursSurLeBouton++;
	}

	void Update() {
		if (nombreDeJoueursSurLeBouton > 0) {
			if (activeTimer.GetComponent<Timer>().TimeUp()) {
				daylight.Toggle();
				Destroy(gameObject);
			}
		}
	}
}
