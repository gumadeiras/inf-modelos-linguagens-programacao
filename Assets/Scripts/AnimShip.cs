using UnityEngine;
using System.Collections;

//Animaçao do navio do Menu Principal
public class AnimShip : MonoBehaviour {

	private int maxposX = 7;
	private int maxposZ = 3;
	private int minposX = -7;
	private int minposZ = -3;
	
	void Start () {
		//posicao inicial
		gameObject.transform.position = new Vector3 (maxposX,  gameObject.transform.position.y, Random.Range(minposZ, maxposZ));
	}

	void Update () {
		//velocidade
		gameObject.transform.Translate (-0.01f, 0, 0);

		//fim da tela
		if (transform.position.x < minposX)
			gameObject.transform.position = new Vector3 (maxposX, gameObject.transform.position.y, gameObject.transform.position.z);
	}
}
