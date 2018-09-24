using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Only set this to Update if you know the screen size can change during a playsession.
		var topWall = gameObject.AddComponent<BoxCollider2D>();
		var bottomWall = gameObject.AddComponent<BoxCollider2D>();
		var leftWall = gameObject.AddComponent<BoxCollider2D>();
		var rightWall = gameObject.AddComponent<BoxCollider2D>();

		
		var mainCam = Camera.main;
		//Move each wall to its edge location:
		topWall.size = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width * 2f, 0f, 0f)).x, 1f);
		topWall.offset = new Vector2 (0f, mainCam.ScreenToWorldPoint (new Vector3 ( 0f, Screen.height, 0f)).y + 0.5f);
		
		bottomWall.size = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width * 2, 0f, 0f)).x, 1f);
		bottomWall.offset = new Vector2 (0f, mainCam.ScreenToWorldPoint (new Vector3( 0f, 0f, 0f)).y - 0.5f);
		
		leftWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height*2f, 0f)).y);;
		leftWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);
		
		rightWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height*2f, 0f)).y);
		rightWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);
	}
}
