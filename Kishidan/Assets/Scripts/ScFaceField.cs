using UnityEngine;
using System.Collections;

public class ScFaceField : MonoBehaviour {
	SpriteRenderer SrRightBackHair;
	GameObject GoRightBackHair;
	// Use this for initialization
	void Start () {
		// このobjectのSpriteRendererを取得
		//MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		// すべての子オブジェクトを取得します
		//foreach(Transform child in transform) {
		//	print(child.name + ":" + child.localPosition);
		//}
		GoRightBackHair = gameObject.transform.FindChild("RightBackHair").gameObject;
		SrRightBackHair = GoRightBackHair.GetComponent<SpriteRenderer>();

		Sprite[] sprites = Resources.LoadAll<Sprite>("Face/neck");
		//Resources.Load<Sprite>(fileName);
		SrRightBackHair.sprite = System.Array.Find<Sprite>(sprites, (sprite) => sprite.name.Equals("neck"));

		//const string BASE_TEXTURE = "Sprites/Face/ear/ear";
		//Sprite ADD_TEXTURE;
		//ADD_TEXTURE = Resources.Load<Sprite>(BASE_TEXTURE);
		//SrRightBackHair.sprite = ADD_TEXTURE;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
