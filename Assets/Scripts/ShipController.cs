using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

	ShipController shipControllerScript;
	
	void Start(){
		GetComponent <ShipController> ();
	}

	void Update () {
		//position
		if (Input.GetKeyDown (KeyCode.DownArrow))
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y - 1, gameObject.transform.position.z);

		if (Input.GetKeyDown (KeyCode.UpArrow))
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z);

		if (Input.GetKeyDown (KeyCode.RightArrow))
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x + 1, gameObject.transform.position.y, gameObject.transform.position.z);

		if (Input.GetKeyDown (KeyCode.LeftArrow))
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x - 1, gameObject.transform.position.y, gameObject.transform.position.z);
	
		//rotation
		if (Input.GetKeyDown (KeyCode.Space))
			gameObject.transform.Rotate(0, 0, 90);

		//Transform position ends
		if (Input.GetKeyDown (KeyCode.D)) {
			shipControllerScript = GetComponent<ShipController> ();
			shipControllerScript.enabled = false;
		}
		  
	}
}
