using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attaque : MonoBehaviour {

	public float force = 100;

	void OnTriggerEnter2D(Collider2D other) {
		var rb = other.gameObject.GetComponent<Rigidbody2D>();
		if (rb) {
			Vector3 forward = transform.TransformDirection(Vector3.up) * force;
			rb.AddForce(forward, ForceMode2D.Impulse);
		}
	}
}
