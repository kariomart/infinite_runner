using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDisplay : MonoBehaviour {

	TileController tile;
	SpriteRenderer cover;
	Color coverColor;

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
		//cover.color = Color.black;
		tile.Clicked ();

	}

	void OnMouseOver() {

			cover.color = Color.white;

	}


	void OnMouseExit() {

			cover.color = coverColor;

	}
}
