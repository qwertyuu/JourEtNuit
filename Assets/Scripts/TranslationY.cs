using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationY : MonoBehaviour {

	public float vitesse = 2;
	public float amplitude = 1;

	private Vector3 initialPosition;

	void Start () {
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = initialPosition + new Vector3(0.0f, Mathf.Cos(Time.time * vitesse) * amplitude, 0.0f);
	}
}
