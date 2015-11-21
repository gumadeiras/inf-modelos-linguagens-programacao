using UnityEngine;
using System.Collections;

public class ClickResponse : MonoBehaviour {

	public bool shotted;
	public Animator anim;


	void Awawke(){
		shotted = false;
	}

	void OnMouseDown(){
	//	Shot ();

	}

	public void Shot(){
		anim.Play("explosionAnim");
		shotted = true;
	}



}