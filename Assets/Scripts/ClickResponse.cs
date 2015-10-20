using UnityEngine;
using System.Collections;

public class ClickResponse : MonoBehaviour {
	public Animator anim;
	private bool shotted;

	void OnMouseDown(){
		anim.Play("explosionAnim");
		shotted = true;

	}

}
