using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleJoueur : MonoBehaviour {
    public float speed = 6.0f;
    public float turnSpeed = 6.0f;
	[SerializeField]
	public int joueur = 1;
	[SerializeField]
	public GameObject attaque;
	[SerializeField]
	public int forceAttaque = 50;
	[SerializeField]
	public float cooldown = 2;

    private Vector2 moveDirection = Vector2.zero;

	private Rigidbody2D rb;

	private bool estEnTrainDattaquer = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
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

		rb.AddForce(moveDirection * speed * 1000 * Time.fixedDeltaTime);
	}

	void Update () {
		if (!estEnTrainDattaquer && Input.GetButtonDown("Attaque_P" + joueur)) {
			StartCoroutine(Attaquer());
		}
	}

	IEnumerator Attaquer() {
		estEnTrainDattaquer = true;
		var attaqueObj = Instantiate(attaque, transform);
		attaqueObj.transform.Translate(0, 0.85f, 0);
		attaqueObj.GetComponent<Attaque>().force = forceAttaque;
		yield return new WaitForSeconds(0.2f);
		Destroy(attaqueObj);
		yield return new WaitForSeconds(cooldown);
		estEnTrainDattaquer = false;
	}
}
