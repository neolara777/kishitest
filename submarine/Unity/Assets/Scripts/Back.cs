using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// 速度
	public Vector2 SPEED = new Vector2(0.04f, 0.04f);
	// Use this for initialization
	void Update () {
		// 移動処理
		Move();
	}

	void Move ()
	{
		// 時間によってYの値が0から1に変化していく。1になったら0に戻り、繰り返す。
		//float y = Mathf.Repeat (Time.time * speed, 1);
		
		// 現在位置をPositionに代入
		Vector2 Position = transform.position;
		// 左キーを押し続けていたら
		if(Input.GetKey("right")){
			float xnum = (float)(Position.x - SPEED.x);
			if (xnum <= 0){
				xnum = 3.2f;
			}
			Position.x = xnum;


		} else if(Input.GetKey("left")){ 
			float xnum = (float)(Position.x + SPEED.x);
			if (xnum >= 6.4){
				xnum = 3.2f;
			}
			Position.x = xnum;
	
		} else if(Input.GetKey("down")){ 
			float ynum = (float)(Position.y + SPEED.y);
			if (ynum >= 11.36){
				ynum = 5.60f;
			}
			Position.y = ynum;
		} else if(Input.GetKey("up")){ 
			float ynum = (float)(Position.y - SPEED.y);
			if (ynum <= 0){
				ynum = 5.60f;
			}
			Position.y = ynum;
		}
		// 現在の位置に加算減算を行ったPositionを代入する
		transform.position = Position;
	}
}
