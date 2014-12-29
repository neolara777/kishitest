using UnityEngine;
using System.Collections;

public class Logo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D (Collider2D c)
	{
		GameManager.isSound = true;
		GameManager.SoundGB ();
		GameManager.isSound = false;

	}
	IEnumerator OnTriggerExit2D (Collider2D c)
	{
		rigidbody2D.velocity = Vector3.zero;
		rigidbody2D.angularVelocity = 0f;
		rigidbody2D.gravityScale = 0f;
		yield return new WaitForSeconds (2);
		GameManager.isSound = true;
		yield return new WaitForSeconds (1);
		GameManager.SoundBgm ();
						GameManager.CameraChange ();

	}
}
