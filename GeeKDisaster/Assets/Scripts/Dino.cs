using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour {

	public static int DinoCount=0;
	public int DinoValue=1;

	// Se llama al iniciar el juego
	void Awake () {
		Dino.DinoCount += DinoValue;
	}


	//cuando se destruye un objeto
	void OnDestroy(){
		Dino.DinoCount -= DinoValue;
		UI_dinos.UpdateDinos();

		if (Dino.DinoCount <= 0) {
		
			Debug.Log ("Todos eliminados");
		}
	
	}

	void OnTriggerEnter(Collider OtherCollider){

		if (OtherCollider.CompareTag ("Player")) {
			Destroy (gameObject);

		}

	}







}
