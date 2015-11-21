using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	//Botao Novo Jogo
	public void NewGame(){
		Application.LoadLevel ("Game");	
	}
	//Botao Sair
	public void Quit(){
		Application.Quit ();	
	}
	// Botao Voltar
	public void Back(){
		Application.LoadLevel ("MainMenu");	
	}
}
