using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Sc_Tx_update : MonoBehaviour {
	//GameManager targetScript;

	// Use this for initialization
	void Start () {
		//targetScript = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text> ().text = GameManager.GetAge ().ToString();
	
		//targetScript.IncreaseAge ();
	}
}
