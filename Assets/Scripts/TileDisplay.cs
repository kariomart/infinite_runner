using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDisplay : MonoBehaviour {

	TileController tile;
	public SpriteRenderer cover;
	public Color coverColor;
	public SpriteRenderer tileSprite;
	public SpriteRenderer specialSprite;
	public Sprite spr;

	// Use this for initialization
	void Start () {

		tile = GetComponent<TileController> ();
		cover = GetComponentInChildren<SpriteRenderer> ();
		coverColor = cover.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {

		Debug.Log ("tile at position " + tile.pos + " clicked.");

		if (Master.me.selectedTile != null) {
			Master.me.selectedTile.GetComponent<TileDisplay> ().cover.color = coverColor;
		}
		cover.color = Color.black;
		tile.Clicked ();

	}

	void OnMouseOver() {

		//cover.color = Color.white;

	}


	void OnMouseExit() {

		//cover.color = coverColor;

	}

	public void setSprite(Sprite spr) {

		this.spr = spr;

	}
}
