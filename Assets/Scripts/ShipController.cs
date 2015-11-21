using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

	public GameObject block;
	private BlockControl blockControl;
	public int shotCount = 3;
	public bool move = true;

	public int posX;
	public int maxPosX = 9;
	public int minPosX = 5;
	public int posY;
	public int maxPosY = 5;
	public int minPosY = 1;
	public int Horizontal;

	private BlockControl bc;

	void Start(){
		//Se for navio da Inteligencia Artificial nao ira mexer
		if (move == false) {
			ShipPosition();
		}
	}

	void Update () {
		//Definir posiçao do navio
		if (move == true) {
			if (Input.GetKeyDown (KeyCode.DownArrow))
				gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y - 1, gameObject.transform.position.z);

			if (Input.GetKeyDown (KeyCode.UpArrow))
				gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z);

			if (Input.GetKeyDown (KeyCode.RightArrow))
				gameObject.transform.position = new Vector3 (gameObject.transform.position.x + 1, gameObject.transform.position.y, gameObject.transform.position.z);

			if (Input.GetKeyDown (KeyCode.LeftArrow))
				gameObject.transform.position = new Vector3 (gameObject.transform.position.x - 1, gameObject.transform.position.y, gameObject.transform.position.z);
	
			//Definir rotaçao
			if (Input.GetKeyDown (KeyCode.Space))
			{
				transform.Rotate (0,0, 90);
			}
			//Transform position ends
			if (Input.GetKeyDown(KeyCode.Return)) {
				move = false;
			}
		}
		  
	}

	void OnTriggerEnter2D(Collider2D col){
		bc = (BlockControl)col.gameObject.GetComponent<BlockControl> ();

		if (col.gameObject.tag == "block") {
			bc.busyBlock += 1;
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if(col.gameObject.tag == "ship1"){
			ShipPosition();
		}
	}

	void OnTriggerExit2D(Collider2D col){
		bc = (BlockControl)col.gameObject.GetComponent<BlockControl>();

		if (col.gameObject.tag == "block") {
			bc.busyBlock -= 1;
		}
	}

	//calcula a posiçao do navio da IA randomicamente.
	void ShipPosition(){

		Horizontal = Random.Range (0, 10);

		if (Horizontal > 5) {
			gameObject.transform.eulerAngles = new Vector3 (0, 0, 90);
			posX = Random.Range (minPosX, maxPosX);
			posY = Random.Range (minPosY+1, maxPosY-1);
			gameObject.transform.position = new Vector3 (posX, posY, gameObject.transform.position.z);
		} else {
			gameObject.transform.eulerAngles = new Vector3 (0, 0, 0);
			posX = Random.Range (minPosX+1, maxPosX-1);
			posY = Random.Range (minPosY, maxPosY);
			gameObject.transform.position = new Vector3 (posX, posY, gameObject.transform.position.z);
		
		}
	}
}
