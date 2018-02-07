﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Master : MonoBehaviour {

	public static Master me;
	public PlayerMovement player;

	public Dictionary<Vector2, GameObject> tiles = new Dictionary<Vector2, GameObject>();
	public List<TileController> tileControllers = new List<TileController> ();
	public List<GameObject> deck = new List<GameObject> ();
	public List<GameObject> hand = new List<GameObject>();
	public List <GameObject> discard = new List<GameObject> ();
	public List<GameObject> cards = new List<GameObject>();
	public List<EnemyController> enemies = new List<EnemyController>();
	public TileController[,] map;
	public TileController selectedTile;


	public GameObject handParent;
	public GameObject deckParent;
	public GameObject discardParent;

	public Text healthText;
	public Text goldText;
	public Text energyText;

	public GameObject handStart;
	public float handOffset;
	public int handSize;
	public int maxEnergy = 3;


	// Use this for initialization
	void Start () {


		if (me == null) {
			me = this;
		} else {
			Destroy (this);
		}
			
		UpdateLists ();	
		DrawHand ();
		GetEnemies ();
		//CardstoDeck ();

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Q)) {
			DebugPrint ();
		}

		UpdateInfoDisplay ();
		
	}

	public void DrawCard() {

		if (deck.Count > 0 && hand.Count < 5) {
			int rand = Random.Range (0, deck.Count);

			GameObject card = deck [rand];

			deck.RemoveAt (rand);
			hand.Add (card);

			//card.transform.position = new Vector3 (handStart.transform.position.x + (handOffset * hand.Count), handStart.transform.position.y, handStart.transform.position.z);
			card.transform.parent = handParent.transform;
			card.gameObject.SetActive (true);

			UpdateCardPositions ();
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
		discard.Add(card);

		card.transform.position = new Vector3(deckParent.transform.position.x, deckParent.transform.position.y, 5);
		card.transform.parent = discardParent.transform;
		card.gameObject.SetActive (false);

	}

	public void DiscardCard(Card card) {

		hand.Remove (card.gameObject);
		discard.Add (card.gameObject);
		card.transform.position = new Vector3(deckParent.transform.position.x, deckParent.transform.position.y, 5);
		card.transform.parent = discardParent.transform;
		card.gameObject.SetActive (false);

	}

	public void DiscardToDeck() {

		//foreach (Transform child in discardParent.transform) {
		int num = discardParent.transform.childCount;
		for (int i = 0; i < num; i++) {
			//Debug.Log ("transferred " + child.gameObject.name);
			discardParent.transform.GetChild(0).parent = deckParent.transform;

		}
			

		UpdateLists ();
		Debug.Log ("Reshuffling Deck");

	}

	public void HandToDiscard() {

		int num = handParent.transform.childCount;
		for (int i = 0; i < num; i++) {
			//Debug.Log ("transferred " + child.gameObject.name);
			Transform obj = handParent.transform.GetChild(0);
			obj.parent = discardParent.transform;
			obj.gameObject.SetActive (false);
		}
		UpdateLists ();
	}

	public void EndTurn() {

		HandToDiscard ();

		if (deck.Count < handSize) {
			DiscardToDeck ();
			DrawHand ();
		} else {
			DrawHand ();
		}


		UpdateLists ();
		UpdateCardPositions ();
		MoveEnemies ();
		PlayerMovement.me.energy = maxEnergy;
	}

	void GetEnemies() {

		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject o in objs) {
			enemies.Add (o.GetComponent<EnemyController>());
		}

	}

	void MoveEnemies() {

		foreach (EnemyController e in enemies) {
			e.MoveTowardsPlayer ();
		}
	}

	void UpdateCardPositions() {

		for (int i = 0; i < hand.Count; i ++) {
			hand [i].GetComponent<CardDisplay> ().UpdatePosition (i);
		}

	}

	void UpdateInfoDisplay() {

		goldText.text = "GOLD: " + PlayerMovement.me.gold;
		healthText.text = "HEALTH: " + PlayerMovement.me.health;
		energyText.text = "ENERGY: " + PlayerMovement.me.energy;



	}

	void UpdateLists() {

		hand.Clear ();
		deck.Clear ();
		discard.Clear ();

		foreach (Transform child in handParent.transform) {

			hand.Add (child.gameObject);

		}

		foreach (Transform child in deckParent.transform) {

			deck.Add (child.gameObject);

		}

		foreach (Transform child in discardParent.transform) {

			discard.Add (child.gameObject);

		}


	}
		

	void DebugPrint() {
		
		string handString = "";
		string deckString = "";
		string discardString = "";

		foreach (GameObject card in hand) {
			//Debug.Log ("HAND: " + card.name);
			handString += card.tag + "|| ";
		}
			

		foreach (GameObject card in deck) {
			deckString += card.tag + "|| ";
		}

		foreach (GameObject card in discard) {
			discardString += card.tag + "|| ";
		}

		Debug.Log ("HAND " + handString);
		Debug.Log ("DECK " + deckString);
		Debug.Log ("DISCARD " + discardString);
	}


}
