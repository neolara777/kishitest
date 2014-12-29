using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	public Vector2 SPEED = new Vector2(0.04f, 0.04f);
	void OnAnimationFinish ()
	{
		Destroy (gameObject);
	}
	void Update () {

		// 現在位置をPositionに代入
		Vector2 Position = transform.position;
		// 左キーを押し続けていたら
		if(Input.GetKey("right")){
			Position.x = Position.x - SPEED.x;				
		} else if(Input.GetKey("left")){ 
			Position.x = Position.x + SPEED.x;			
		} else if(Input.GetKey("down")){ 
			Position.y = Position.y + SPEED.y;
		} else if(Input.GetKey("up")){ 
			Position.y = Position.y - SPEED.y;
		}
		// 現在の位置に加算減算を行ったPositionを代入する
		transform.position = Position;
	}
}
