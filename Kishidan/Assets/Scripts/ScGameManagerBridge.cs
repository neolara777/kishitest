using UnityEngine;
using System.Collections;

public class ScGameManagerBridge : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void IncreaseAge () {
		GameManager.IncreaseAge ();		
	}

	public void DereaseAge () {
		GameManager.DereaseAge ();		
	}
}
