using UnityEngine;
using System.Collections;

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
		AudioSource.PlayClipAtPoint (explosion, new Vector3 (0, 0, 0));
		anim.Play("explosionAnim");
		shotted = true;
		if (busyBlock == 1 && aiblock == false) {
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
