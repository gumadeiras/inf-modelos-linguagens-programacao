using UnityEngine;
using System.Collections;

public class shipManager : MonoBehaviour {

	public GameObject ship;
	public int maxShips = 3;
	private int shipCount;

	public int shipShots;
	public int shipShotsIA;

	public GameObject win;
	public GameObject lose;

	public GameObject block;

	void Start (){
		shipShots = 9;
		shipShotsIA = 9;
	}

	void Update () {

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
