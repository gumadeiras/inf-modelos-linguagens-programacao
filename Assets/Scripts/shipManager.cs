using UnityEngine;
using System.Collections;
using System;

public class shipManager : MonoBehaviour {

	public GameObject ship;
	public int maxShips = 3;
	private int shipCount;

	public int shipShots;
	public int shipShotsIA;

	public string totalShots;
	public int totalShotsIA;

	public GameObject win;
	public GameObject lose;

	public GameObject block;
	
	public TextMesh points;
	public TextMesh pointsIA;

	public TextMesh shots;
	public TextMesh shotsIA;
	void Start (){

		Func<string,string,string> concatena = (x,y) => x+y;
		Func<string,Func<string,string>> curryString = Lambda.Curry(concatena);
		Func<string,string> concatenaCom = curryString("Rodada");


		totalShotsIA = 1;
		totalShots = concatenaCom(":");
		shipShots = 9;
		shipShotsIA = 9;
	}

	void Update () {

		points.text = shipShots.ToString () + "/9";
		pointsIA.text = shipShotsIA.ToString () + "/9";
		shots.text = totalShots;
		shotsIA.text = totalShotsIA.ToString ();

		if (Input.GetKeyDown (KeyCode.Return) && shipCount < maxShips) {
			SpawnShip();
		}

		if (shipShots == 0) {
			lose.SetActive(true);
			Invoke ("End", 5);
		} else if (shipShotsIA == 0) {
			win.SetActive(true);
			Invoke ("End", 3);

		}
	}

	void SpawnShip(){
		GameObject currentShip = Instantiate (ship) as GameObject;
		currentShip.SetActive (true);
		shipCount++;
	}

	void End(){
		Application.LoadLevel ("MainMenu");
	}
	
}
