using UnityEngine;
using System.Collections;

public class Topid : MonoBehaviour {

	public int speed = 10;
	public Vector2 SPEED = new Vector2(0.04f, 0.04f);

	void Start ()
	{
		rigidbody2D.velocity = transform.up.normalized * speed;

	}
	void Update () {
		Move ();
	}
	void Move ()
	{
		// 時間によってYの値が0から1に変化していく。1になったら0に戻り、繰り返す。
		//float y = Mathf.Repeat (Time.time * speed, 1);
		
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

		float ynum = (float)(Position.y - SPEED.y);

		//画面の外に出たら削除
		if (Position.y >= 11.36 || 
		    Position.y <= 0 ||
		    Position.x >= 6.4 || 
		    Position.x <= 0
		    ){
			Destroy (gameObject);
		}


	}
}
