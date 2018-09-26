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
	[SerializeField]
	public Sprite daySkin;
	[SerializeField]
	public Sprite daySkinHover;
	[SerializeField]
	public Sprite nightSkin;
	[SerializeField]
	public Sprite nightSkinHover;

	private int nombreDeJoueursSurLeBouton = 0;
	private GameObject activeTimer;

	void Start() {
		GetComponent<SpriteRenderer>().sprite = daylight.isNight() 
			? daySkin
			: nightSkin;
		GetComponent<SpriteRenderer>().drawMode = SpriteDrawMode.Sliced;
		GetComponent<SpriteRenderer>().size = new Vector2(0.18f, 0.18f);
	}

	void DeleteTimer() {
		GetComponent<SpriteRenderer>().sprite = daylight.isNight() 
			? daySkin
			: nightSkin;
		Destroy(activeTimer);
	}

	void NewTimer() {
		var t = Instantiate(timer, transform);
		t.transform.Translate(0, 1, 0);
		t.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
		
		t.GetComponent<Timer>().temps = tempsPourAppuyer;
		activeTimer = t;
		GetComponent<SpriteRenderer>().sprite = daylight.isNight() 
			? daySkinHover
			: nightSkinHover;
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
