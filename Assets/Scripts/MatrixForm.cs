using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MatrixForm: MonoBehaviour {
	int c = 0;
	public int lines;
	public int columns;
	public GameObject matrixUnity;
	public List<GameObject> block;

	void Start(){
		
		//Instantiate Objects
		for (int i = 0; i < lines*columns; i++) {
			GameObject tempBuild = Instantiate(matrixUnity) as GameObject;
			block.Add(tempBuild);
			tempBuild.SetActive(true);
		}

		//Define matrix position
		for(int j = 0; j < columns; j++){
			for (int i = 0; i < lines; i++) {
				
				block [c].transform.position = new Vector3 (block [0].transform.position.x + i, 
				                                            block [0].transform.position.y - j , 0);
				
				c++;
			}
		}
	
	}

}
