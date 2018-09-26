using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	[SerializeField]
	public DayController daylight;
	[SerializeField]
	public Text daytext;
	[SerializeField]
	public Text nighttext;
	[SerializeField]
	public GameObject daywin;
	[SerializeField]
	public GameObject nightwin;
	[SerializeField]
	public int time = 30;
	[SerializeField]
	public GameObject button;
	[SerializeField]
	public GameObject indicateur;
	[SerializeField]
	public GameObject[] joueurs;

	private float daySecondsLeft;
	private float nightSecondsLeft;
	private bool gameRunning = true;
	private GameObject spawnedIndicator = null;
	private GameObject spawnedButton = null;

	void Start() {
		daySecondsLeft = time + 0.499999f;
		nightSecondsLeft = time + 0.499999f;
		UpdateDayText(Mathf.RoundToInt(daySecondsLeft).ToString());
		UpdateNightText(Mathf.RoundToInt(nightSecondsLeft).ToString());
		StartCoroutine(RandomButton(true));
	}
	
	// Update is called once per frame
	void Update () {
		int updatedSecondsLeft;
		if (daylight.isDay()) {
			daySecondsLeft -= Time.deltaTime;
			updatedSecondsLeft = Mathf.RoundToInt(daySecondsLeft);
			UpdateDayText(updatedSecondsLeft.ToString());
			SetDayTheme();
		} else {
			nightSecondsLeft -= Time.deltaTime;
			updatedSecondsLeft = Mathf.RoundToInt(nightSecondsLeft);
			UpdateNightText(updatedSecondsLeft.ToString());
			SetNightTheme();
		}

		if (gameRunning && updatedSecondsLeft == 0) {
			(daylight.isDay() ? daywin : nightwin).SetActive(true);
			if (spawnedButton != null) {
				Destroy(spawnedButton);
			}
			gameRunning = false;
		}

		if (gameRunning && spawnedIndicator == null && spawnedButton == null) {
			StartCoroutine(RandomButton());
		}
	}

	IEnumerator RandomButton(bool now = false) {
		var minwidth = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x;
		var maxwidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x;
		var minheight = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y;
		var maxheight = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y;
		spawnedIndicator = Instantiate(indicateur, new Vector3(Random.Range(minwidth, maxwidth), Random.Range(minheight + 0.5f, maxheight)), Quaternion.identity);
		if (!now) {
        	yield return new WaitForSeconds(1);
		}
		spawnedButton = Instantiate(button, spawnedIndicator.transform.position, Quaternion.identity);
		Destroy(spawnedIndicator);
		spawnedButton.GetComponent<LightToggle>().daylight = daylight;
		spawnedButton.SetActive(true);
	}

    private bool ButtonIsInPlayers(GameObject button)
    {
		var spawnedButtonBounds = button.GetComponent<Collider2D>().bounds;
        return joueurs.All((joueur) => joueur.GetComponent<Collider2D>().bounds.Intersects(spawnedButtonBounds));
    }

    void UpdateDayText(string text) {
		if (gameRunning) {
			daytext.text = "Jour: " + text + "s";
		}
	}

	void UpdateNightText(string text) {
		if (gameRunning) {
			nighttext.text = "Nuit: " + text + "s";
		}
	}

	void SetNightTheme() {
		nighttext.color 
		= daytext.color = new Color(205 / 255f, 205 / 255f, 205 / 255f);
	}

	void SetDayTheme() {
		nighttext.color 
		= daytext.color = new Color(50 / 255f, 50 / 255f, 50 / 255f);
	}
}
