using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_dinos : MonoBehaviour {

	private static Text TextDino;
	private static int TargetDinos=0;

	// Use this for initialization
	void Start () {
		
		TextDino = GetComponent<Text>();
		TargetDinos = Dino.DinoCount;
		UpdateDinos ();
		
	}
	
	// Update is called once per frame
	void Update () {
				
	}

	public static void UpdateDinos(){
		
		int RemainingDinos = Dino.DinoCount;
		int CollectedDinos = TargetDinos - RemainingDinos;
		if (RemainingDinos > 0) {
			TextDino.text = "Enemigos \n" + CollectedDinos + "/" + TargetDinos;

		} else {
			TextDino.alignment = TextAnchor.LowerCenter;
			TextDino.text = "Mundo liberado!";

		}
	
	}
}
