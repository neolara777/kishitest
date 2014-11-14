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

	public static int GetAge() {
		return age;
	}
	
}
