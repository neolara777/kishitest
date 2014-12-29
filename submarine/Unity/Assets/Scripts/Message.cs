using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Message : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Text target = null;
		if (GameManager.GetAge () <= 0) {				
				target = gameObject.GetComponent<Text> ();
				target.text = "GameOver!!" ;
		}
		GameObject btnokori = GameObject.Find ("/BattleShip");
		GameObject clnokori = GameObject.Find ("/Cluiser");
		if (!btnokori && !clnokori) {
			target = gameObject.GetComponent<Text> ();
			target.text = "Clear!!!!" ;
		}
	}
}
