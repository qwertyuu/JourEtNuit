using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortByY : MonoBehaviour {
	private float topPos;

	[SerializeField]
	public int offset;

	[SerializeField]
	public bool isDynamic;

	private SpriteRenderer SpriteRenderer;
	// Use this for initialization
	void Start () {
		topPos = Camera.main.ScreenToWorldPoint (new Vector3 ( 0f, Screen.height, 0f)).y;
		SpriteRenderer = GetComponent<SpriteRenderer>();
		if (!isDynamic) {
			UpdateOrder();
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isDynamic) {
			UpdateOrder();
		}
	}

	private void UpdateOrder()
	{
		SpriteRenderer.sortingOrder = Mathf.RoundToInt((topPos - transform.position.y) * 10) + offset;
	}
}
