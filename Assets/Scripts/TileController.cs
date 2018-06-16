using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {

	public SpriteRenderer cover;
	public TileDisplay display;
	public Vector2 pos;
	public GameObject card;
	public Card cardData;
	public SpriteRenderer sprite;
	public Sprite defaultTile;
	
	public Sprite spr;

	// Use this for initialization

	public void init() {

		if (cardData) {
			spr = cardData.sprite;
		}

		if (spr) {
			
			Debug.Log(cardData);
			display.setSprite(spr);
		}
	}


	void Start () {

		pos = (Vector2) (transform.position);
		//sprite = GetComponent<SpriteRenderer> ();
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
			Master.me.cardDescription.text = ("added " + card.name + " to deck!");
			card = null;
			display.tileSprite.sprite = defaultTile;
		}

	}


}
