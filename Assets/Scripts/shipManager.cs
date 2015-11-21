using UnityEngine;
using System.Collections;

public class shipManager : MonoBehaviour {

	public GameObject ship;
	public int maxShips = 3;
	private int shipCount;

	public int shipShots;
	public int shipShotsIA;

	void Start (){
		shipShots = 9;
		shipShotsIA = 9;
	}

	void Update () {

		if (Input.GetKeyDown (KeyCode.Return) && shipCount < maxShips) {
			SpawnShip();
		}

		if (shipShots == 0 || shipShotsIA == 0) {

			Application.LoadLevel("GameOver");
		}
	}

	void SpawnShip(){
		GameObject currentShip = Instantiate (ship) as GameObject;
		currentShip.SetActive (true);
		shipCount++;
	}
	
}
