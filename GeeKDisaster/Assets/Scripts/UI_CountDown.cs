using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class UI_CountDown : MonoBehaviour {

	private Text TextCountDown;

	private float CountDownTimerDuration;
	private float CountDownTimerStartTime;


	// Use this for initialization
	void Start () {
		TextCountDown = GetComponent<Text> ();
		SetupCountDownTimer (300);

	}
	
	// Update is called once per frame
	void Update () {

		string TimerMessage = "Fin del juego";

		int TimeLeft = (int)CountDownTimeRemaining ();

		if (TimeLeft > 0) {
			TimerMessage = "Tiempo: " + LeadingZero (TimeLeft);
		}

		TextCountDown.text = TimerMessage;

		}


	private void SetupCountDownTimer(float DelayInSeconds){
		CountDownTimerDuration = DelayInSeconds;
		CountDownTimerStartTime = Time.time;
	}

	private float CountDownTimeRemaining(){
		float ElapsedSeconds = Time.time - CountDownTimerStartTime;
		float Timeleft = CountDownTimerDuration - ElapsedSeconds;

		return Timeleft;
	}

	private string LeadingZero(int n){
		return n.ToString().PadLeft(3,'0');
	
	}
}
