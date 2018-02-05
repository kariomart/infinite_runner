﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour {

	public static Master me;
	public PlayerMovement player;

	public Dictionary<Vector2, GameObject> tiles = new Dictionary<Vector2, GameObject>();
	public List<TileController> tileControllers = new List<TileController> ();
	public List<GameObject> deck = new List<GameObject> ();
	public List<GameObject> hand = new List<GameObject>();
	public List<GameObject> cards = new List<GameObject>();
	public TileController[,] map;
	public TileController selectedTile;


	public GameObject handParent;
	public GameObject deckParent;

	public GameObject handStart;
	public float handOffset;
	public int handSize;


	// Use this for initialization
	void Start () {

		if (me == null) {
			me = this;
		} else {
			Destroy (this);
		}

		UpdateLists ();	
		DrawHand ();
		//CardstoDeck ();

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Q)) {
			DebugPrint ();
		}
		
	}

	public void DrawCard() {

		if (deck.Count > 0 && hand.Count < 5) {
			int rand = Random.Range (0, deck.Count - 1);

			GameObject card = deck [rand];

			deck.RemoveAt (rand);
			hand.Add (card);

			//card.transform.position = new Vector3 (handStart.transform.position.x + (handOffset * hand.Count), handStart.transform.position.y, handStart.transform.position.z);
			card.transform.parent = handParent.transform;
			card.gameObject.SetActive (true);

			for (int i = 0; i < hand.Count; i ++) {
				hand [i].GetComponent<CardDisplay> ().UpdatePosition (i);
			}

		} else {
			Debug.Log ("deck empty or hand full");
		}

	}

	public void DrawHand() {

		for (int i = 0; i < handSize; i ++) {
			DrawCard ();
		}



	}

	public bool CheckMovementCard() {

		if (PlayerMovement.me.moves > 0) {
			PlayerMovement.me.moves--;
			return true;
		}

		for(int i = 0; i < hand.Count; i ++) {
			GameObject currentCard = hand [i];

			if (currentCard.tag == "MovementCard") {

				DiscardCard (i);
				return true;


			}

		}

		return false;



	}
		

	public void AddCard (GameObject card) {

		GameObject newCard = Instantiate (card, deckParent.transform);
		deck.Add (newCard);
		newCard.SetActive (false);
//		newCard.transform.parent = deckParent.transform;

	}

	public void DiscardCard(int index) {

		GameObject card = hand [index];

		hand.RemoveAt(index);
		deck.Add (card);

		card.transform.position = new Vector3(deckParent.transform.position.x, deckParent.transform.position.y, 5);
		card.transform.parent = deckParent.transform;
		card.gameObject.SetActive (false);

	}

	public void DiscardCard(Card card) {

		hand.Remove (card.gameObject);
		deck.Add (card.gameObject);
		card.transform.position = new Vector3(deckParent.transform.position.x, deckParent.transform.position.y, 5);
		card.transform.parent = deckParent.transform;
		card.gameObject.SetActive (false);

	}
		

	void UpdateLists() {

		hand.Clear ();
		deck.Clear ();

		foreach (Transform child in handParent.transform) {

			hand.Add (child.gameObject);

		}

		foreach (Transform child in deckParent.transform) {

			deck.Add (child.gameObject);

		}


	}
		
		

	void DebugPrint() {
		string handString = "";
		string deckString = "";

		foreach (GameObject card in hand) {
			//Debug.Log ("HAND: " + card.name);
			handString += card.tag + "|| ";
		}
			

		foreach (GameObject card in deck) {
			deckString += card.tag + "|| ";
		}

		Debug.Log ("HAND " + handString);
		Debug.Log ("DECK " + deckString);
	}


}
