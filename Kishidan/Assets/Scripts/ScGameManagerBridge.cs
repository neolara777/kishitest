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

	public void CameraChange () {
		GameManager.CameraChange ();		
	}
	public void CameraChange2 () {
		GameManager.CameraChange2 ();		
	}

	public void CanvasChange () {
		GameManager.CanvasChange ();		
	}
}
