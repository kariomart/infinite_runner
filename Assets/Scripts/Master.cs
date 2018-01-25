using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour {

	public static Master me;
	public PlayerMovement player;

	public List<GameObject> tiles = new List<GameObject>();
	public List<Card> deck = new List<Card> ();
	public List<Card> hand = new List<Card>();
	public List<Card> cards = new List<Card>();
	public GameObject handParent;

	// Use this for initialization
	void Start () {

		if (me == null) {
			me = this;
		} else {
			Destroy (this);
		}

		DrawHand ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DrawCard() {



	}

	public void DrawHand() {



	}


}
