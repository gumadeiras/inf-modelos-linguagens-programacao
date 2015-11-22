using UnityEngine;
using System.Collections;
using System;

public class BlockControl : MonoBehaviour {

	public bool shotted;
	public bool aiblock = true;
	public int busyBlock = 0;
	public bool shottedd;
	
	public AudioClip explosion;
	public Animator anim;

	void Awake(){
		shotted = false;
	}
	
	void Start(){
		shottedd = false;
	}
	
	void OnMouseDown(){
		if (aiblock == false) {
			Shot ();
			AIShot ();
		}
	}

	public void Shot(){
		Func<int,int,int> Adiciona = (x,y) => x+y;
		Func<int,Func<int,int>> curryInt = Lambda.Curry(Adiciona);
		Func<int,int> decrementaUm = curryInt(-1);

		shipManager sm = GameObject.Find("ShipManager").GetComponent<shipManager>();
		AudioSource.PlayClipAtPoint (explosion, new Vector3 (0, 0, 0));
		anim.Play("explosionAnim");
		shotted = true;
		if (busyBlock == 1 && aiblock == false) {
			sm.shipShotsIA = decrementaUm(sm.shipShotsIA);
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
