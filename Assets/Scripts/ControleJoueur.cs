using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleJoueur : MonoBehaviour {
    public float speed = 6.0f;
    public float turnSpeed = 6.0f;
	[SerializeField]
	public int joueur = 1;

    private Vector2 moveDirection = Vector2.zero;

	private Rigidbody2D a;

	// Use this for initialization
	void Start () {
		a = GetComponent<Rigidbody2D>();
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		//a.isKinematic = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		moveDirection = new Vector2(Input.GetAxis("Horizontal_P" + joueur), Input.GetAxis("Vertical_P" + joueur));
		var mag = moveDirection.magnitude;
		GetComponent<Animator>().speed = mag * 5;
		if (mag > 0.1f) {
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			var goalRot = Quaternion.AngleAxis(angle - 90, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, goalRot, turnSpeed * Time.fixedDeltaTime);
		}

		a.AddForce(moveDirection * speed * 1000 * Time.fixedDeltaTime);
	}
}
