using UnityEngine;
using System.Collections;

public class ScLogo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	
	
	}

	private IEnumerator OnTriggerEnter2D (Collider2D c){
		PlayAudio ();
		yield return new WaitForSeconds(2);
		GameManager.CameraChange2 ();

	}

	public void PlayAudio(){
		Debug.Log("test"); 
		audio.Play();

	}

}
