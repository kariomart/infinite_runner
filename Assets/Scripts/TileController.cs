using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {

	public SpriteRenderer cover;
	public TileDisplay display;
	public Vector2 pos;
	public GameObject card;
	public SpriteRenderer sprite;
	public Sprite defaultTile;

	// Use this for initialization
	void Start () {

		pos = (Vector2) (transform.position);
		sprite = GetComponent<SpriteRenderer> ();
		//cover = GetComponent<SpriteRenderer> ();
		display = GetComponent<TileDisplay> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Master.me.selectedTile != this) {
			cover.color = display.coverColor;
		}
		
	}

	public virtual void TileEntered() {



	}

	public void RevealTile() {

		cover.enabled = false;

	}

	public void Clicked() {

		Master.me.selectedTile = this;

	}

	public void GiveCard() {

		if (card != null) {
			Master.me.AddCard (card);
			Debug.Log ("added " + card.name + "!");
			card = null;
			display.tileSprite.sprite = defaultTile;
		}

	}



	void OnTriggerEnter2D(Collider2D coll) {

		Debug.Log ("collided");
		if (coll.gameObject.tag == "Vision") {

			cover.enabled = false;

		}

	}
}
