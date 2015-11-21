using UnityEngine;
using System.Collections;

public class BlockControl : MonoBehaviour {


	public bool shotted;
	public Animator anim;

	public bool busyBlock;
	public bool shottedd;

	public bool aiblock = true;

	void Start(){
		busyBlock = false;
		shottedd = false;
	}

	void Awawke(){
		shotted = false;
	}
	
	void OnMouseDown(){
		if (aiblock == false) {
			Shot ();
			AIShot ();
		}
		
	}
	
	public void Shot(){
		anim.Play("explosionAnim");
		shotted = true;
		if (busyBlock == true && aiblock == false) {
			shipManager sm = GameObject.Find("ShipManager").GetComponent<shipManager>();
			sm.shipShotsIA -= 1;
			
		}
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
		Invoke ("SetFalse", 1.8f);

	}
	public void SetFalse(){
		gameObject.SetActive (false);


	}

	void AIShot(){

		MatrixForm mf =  GameObject.Find("SpawnerMatrix").GetComponent<MatrixForm>();
		mf.CompareShot ();

	}
	
}
