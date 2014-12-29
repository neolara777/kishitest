using UnityEngine;
using System.Collections;

public class MainUnit : MonoBehaviour {
	// PlayerBulletプレハブ
	public GameObject topid;
		// Use this for initialization
	void Start () {
	
	
	}

	// Update is called once per frame
	void Update () {
		/*
		if(Input.GetKey("right") && Input.GetKey("up")){
			transform.rotation = Quaternion.Euler(0, 0, 315);
		} else if(Input.GetKey("right") && Input.GetKey("down")){
			transform.rotation = Quaternion.Euler(0, 0, 225f);
		} else if(Input.GetKey("left")&& Input.GetKey("down")){
			transform.rotation = Quaternion.Euler(0, 0, 135f);
		} else if(Input.GetKey("left")&& Input.GetKey("up")){
			transform.rotation = Quaternion.Euler(0, 0, 45f);
		} else 
		*/
		
		if(Input.GetKey("right")){
			transform.rotation = Quaternion.Euler(0, 0, 270f);
		} else if(Input.GetKey("left")){
			transform.rotation = Quaternion.Euler(0, 0, 90f);
		} else if(Input.GetKey("down")){
			transform.rotation = Quaternion.Euler(0, 0, 180f);
		} else if(Input.GetKey("up")){
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		if(Input.GetKeyDown("space")){
			Instantiate (topid, transform.position, transform.rotation);
			GameManager.SoundTop ();
		}
	}
	void OnTriggerEnter2D (Collider2D c)
	{
		// 弾の削除
		Destroy(c.gameObject);	
		//音を鳴らす
		GameManager.SoundEx ();
		Explosion();

		GameManager.DereaseAge ();
		if (GameManager.GetAge () <= 0) {
			// プレイヤーを削除
			
			Destroy (gameObject);
		}
	}
	// 爆発のPrefab
	public GameObject explosion;
	// 爆発の作成
	public void Explosion ()
	{
		Instantiate (explosion, transform.position, transform.rotation);
	}


}
