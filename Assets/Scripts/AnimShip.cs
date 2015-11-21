using UnityEngine;
using System.Collections;

public class AnimShip : MonoBehaviour {

	private int maxposX = 7;
	private int maxposZ = 3;
	private int minposX = -7;
	private int minposZ = -3;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (maxposX,  transform.position.y, Random.Range(minposZ, maxposZ));
	}
	
	// Update is called once per frame
	void Update () {


		transform.Translate (-0.01f, 0, 0);

		if (transform.position.x < minposX)
			transform.position = new Vector3 (maxposX, transform.position.y, transform.position.z);


	
	}
}
