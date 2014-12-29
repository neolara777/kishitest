using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	SpriteRenderer spriteRenderer;
	public int speed = 1;
	public int score = 100;
	// 弾のPrefab
	public GameObject bullet;
	public int hitpoint= 5;

	// 爆発のPrefab
	public GameObject explosion;
	
	// 弾の作成
	public void Shot (Transform origin)
	{
		Instantiate (bullet, origin.position, origin.rotation);
		GameManager.SoundFire ();
	}

	// 爆発の作成
	public void Explosion ()
	{
		Instantiate (explosion, transform.position, transform.rotation);
	}



	// Use this for initialization
	IEnumerator  Start () {
		rigidbody2D.velocity = transform.up.normalized * speed;

		while (true) {

			// 子要素を全て取得する
			for (int i = 0; i < transform.childCount; i++) {
				Transform shotPosition = transform.GetChild(i);
				Shot (shotPosition);
			}			
			// shotDelay秒待つ
			yield return new WaitForSeconds (3);
		}

	}
	// 速度
	public Vector2 SPEED = new Vector2(0.04f, 0.04f);
	// Update is called once per frame
	void Update () {
		Move ();
	}
	void Move ()
	{
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
		if (Position.x >= 8.4f) {
			transform.rotation = Quaternion.Euler(0, 0, 90f);
			rigidbody2D.velocity = transform.up.normalized * speed;
		} else if (Position.x <= -2) {
			transform.rotation = Quaternion.Euler(0, 0, 270f);
			rigidbody2D.velocity = transform.up.normalized * speed;
		} else if (Position.y >= 8.4f) {
			transform.rotation = Quaternion.Euler(0, 0, 180f);
			rigidbody2D.velocity = transform.up.normalized * speed;
		} else if (Position.y <= -2) {
			transform.rotation = Quaternion.Euler(0, 0, 0);
			rigidbody2D.velocity = transform.up.normalized * speed;
		}
		// 現在の位置に加算減算を行ったPositionを代入する
		transform.position = Position;
	}
	void OnTriggerEnter2D (Collider2D c)
	{
		// 弾の削除
		Destroy(c.gameObject);
		//音を鳴らす
		GameManager.SoundEx ();
		Explosion();


		hitpoint = hitpoint - 1;
		if (hitpoint <= 0) {
				GameManager.IncreaseScore (score);
				// プレイヤーを削除				
				Destroy (gameObject);
		} else {
			GameManager.IncreaseScore (score/10);
		}
	}

}
