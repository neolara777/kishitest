using UnityEngine;
using System.Collections;

public class GameManager {
	static int age = 1;

	public static void IncreaseAge () {
		age++;		
	}

	public static void DereaseAge () {
		age--;		
	}

	public static void CameraChange () {
		//GameObject lookTarget = Camera.main;
		GameObject lookTarget = GameObject.FindWithTag("MainCamera");
		lookTarget.transform.localPosition = new Vector3(9.6f, 5.68f, -10f);		
	}

	public static void CameraChange2 () {
		//GameObject lookTarget = Camera.main;
		GameObject lookTarget = GameObject.FindWithTag("MainCamera");
		lookTarget.transform.localPosition = new Vector3(3.2f, 5.68f, -10f);		
	}
	public static void CanvasChange () {
		//GameObject lookTarget = Camera.main;
		GameObject lookTarget = GameObject.Find("CanvasB");
		lookTarget.transform.localPosition = new Vector3(0, 0, 0);		
	}
	public static int GetAge() {
		return age;
	}
	
}
