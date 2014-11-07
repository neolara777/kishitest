using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public int age = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void IncreaseAge () {
		this.age++;		
	}

	public void DereaseAge () {
		this.age--;		
	}

	public int GetAge() {
		return this.age;
	}
	
}
