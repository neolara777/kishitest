using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager {
	static int age = 10;
	static int score = 0;
	//static int myHitpoint= 5;
	static private AudioSource se;
	static private GameObject soundObj;
	static public bool isSound =false;

	public static void SoundEx () {
		if (isSound) {
						soundObj = GameObject.Find ("/Sounds/ex");
						se = soundObj.GetComponent<AudioSource> ();	
						se.Play ();
				}
	}

	public static void SoundTop () {
		if (isSound) {
						soundObj = GameObject.Find ("/Sounds/top");
						se = soundObj.GetComponent<AudioSource> ();	
						se.Play ();
				}
	}

	public static void SoundFire() {
		if (isSound) {
						soundObj = GameObject.Find ("/Sounds/fire");
						se = soundObj.GetComponent<AudioSource> ();	
						se.Play ();
				}
	}

	public static void SoundGB() {
		if (isSound) {
						soundObj = GameObject.Find ("/Sounds/GB");
						se = soundObj.GetComponent<AudioSource> ();	
						se.Play ();
				}
	}

	public static void SoundBgm() {
		if (isSound) {
			soundObj = GameObject.Find ("/Sounds/bgm");
			se = soundObj.GetComponent<AudioSource> ();	
			se.Play ();
		}
	}

	public static void IncreaseAge () {
		age++;		
	}

	public static void DereaseAge () {
		age--;		
	}

	public static void IncreaseScore (int addScore) {
		score = score + addScore;		
	}
	
	public static void DereaseScore () {
		score--;		
	}

	public static void CameraChange () {
		//GameObject lookTarget = Camera.main;
		GameObject lookTarget = GameObject.FindWithTag("MainCamera");
		lookTarget.transform.localPosition = new Vector3(3.2f, 5.68f, -10f);		
	}

	public static void CameraChange2 () {
		//GameObject lookTarget = Camera.main;
		GameObject lookTarget = GameObject.FindWithTag("MainCamera");
		lookTarget.transform.localPosition = new Vector3(-13.32f, 5.68f, -10f);		
	}
	public static void CanvasChange () {
		//GameObject lookTarget = Camera.main;
		GameObject lookTarget = GameObject.Find("CanvasB");
		lookTarget.transform.localPosition = new Vector3(0, 0, 0);		
	}
	public static int GetAge() {
		return age;
	}
	public static int GetScore() {
		return score;
	}
	
}
