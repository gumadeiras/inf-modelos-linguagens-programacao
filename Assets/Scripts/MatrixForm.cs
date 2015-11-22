using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MatrixForm: MonoBehaviour {
	int c = 0;
	public int lines;
	public int columns;
	public GameObject matrixUnity;
	public List<GameObject> block;
	public List<GameObject> block2;

	private int max ;
	private int min = 0;
	public int shots = 0;

	void Start(){
		max = lines * columns;

		//Instantiate Objects
		for (int i = 0; i < lines*columns; i++) {
			GameObject tempBuild = Instantiate(matrixUnity) as GameObject;
			block.Add(tempBuild);
			tempBuild.SetActive(true);
			BlockControl bc = block[i].GetComponent<BlockControl>();
			bc.aiblock = false;

		}

		for (int i = 0; i < lines*columns; i++) {
			GameObject tempBuild2 = Instantiate(matrixUnity) as GameObject;
			block2.Add(tempBuild2);
			tempBuild2.SetActive(true);


		}

		//Define matrix position
		for(int j = 0; j < columns; j++){
			for (int i = 0; i < lines; i++) {
				
				block [c].transform.position = new Vector3 (block [0].transform.position.x + i, 
				                                            block [0].transform.position.y - j , 0);
				
				c++;
			}
		}
		c = 0;

		for(int j = 0; j < columns; j++){
			for (int i = 0; i < lines; i++) {
				if( c != 0)
				block2 [c].transform.position = new Vector3 (block2 [0].transform.position.x - i, 
				                                            block2 [0].transform.position.y - j , 0);

				else 
					block2 [c].transform.position = new Vector3 (-5 +block2 [0].transform.position.x - i, 
					                                             block2 [0].transform.position.y - j , 0);

			
				c++;
			}
		}
	}


	public void CompareShot(){

		Func<int,int,int> Adiciona = (x,y) => x+y;
		Func<int,Func<int,int>> curryInt = Lambda.Curry(Adiciona);
		Func<int,int> decrementaUm = curryInt(-1);
		Func<int,int> incrementaUm = curryInt(1);
		
		BlockControl bc =  block2 [UnityEngine.Random.Range(min, max)].gameObject.GetComponent<BlockControl> ();
		shipManager sm = GameObject.Find("ShipManager").GetComponent<shipManager>();
		if (bc.shottedd == false) {
			bc.shottedd = true;
			shots ++;
			bc.Shot ();


			sm.totalShotsIA = incrementaUm(sm.totalShotsIA);

			if (bc.busyBlock == 1) {	
				sm.shipShots = decrementaUm(sm.shipShots);

			}
		} else if(shots != 25) {
			CompareShot();
		} 

	}

}
