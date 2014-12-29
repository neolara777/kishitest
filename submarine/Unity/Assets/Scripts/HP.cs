using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HP : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Text target = null;
		target = gameObject.GetComponent<Text>();
		target.text = "HP:" + GameManager.GetAge ().ToString();
	}
}
