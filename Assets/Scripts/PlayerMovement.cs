using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	// Call PlayerMovement Player

	public static PlayerMovement me;
	public float cellSize;  // move to Tile
	public float moveSpeed;
	public Vector2 pos;

	public int health = 5;
	public int gold;
	public int moves;
	public int energy = 3;

	public GameObject sprite;



	// Use this for initialization
	void Start () {

		if (me == null) {
			me = this;
		} else {
			Destroy (this);
		}

		sprite = GetComponentInChildren<SpriteRenderer> ().gameObject;


	}
	
	// Update is called once per frame
	void Update () {

		DealWithInput ();
		CheckIfDead ();
			
	}

	void DealWithInput() {


//		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) {
//
//			if (Master.me.CheckMovementCard () && energy > 0) {
//
//				if (MapGenerator.me.CheckTile (new Vector2 (pos.x, pos.y + 1))) {
//					transform.Translate (0, cellSize, 0);
//					pos = (Vector2)transform.position;
//					MapGenerator.me.CheckPlayer ();
//					Master.me.DiscardMovementCard ();
//					energy--;
//				}
//			}
//
//
//		}

//		if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) {
//
//			if (Master.me.CheckMovementCard () && energy > 0) {
//				
//				if (MapGenerator.me.CheckTile (new Vector2 (pos.x, pos.y - 1))) {
//					transform.Translate (0, -cellSize, 0);
//					pos = (Vector2)transform.position;
//					MapGenerator.me.CheckPlayer ();
//					Master.me.DiscardMovementCard ();
//					energy--;
//				}
//			}
//
//		}

		if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) {

			if (Master.me.CheckMovementCard () && energy > 0) {
				
				if (MapGenerator.me.CheckIfOnMap (new Vector2 (pos.x + 1, pos.y))) {
					MapGenerator.me.CheckIfBadTile (new Vector2 (pos.x + 1, pos.y));
					transform.Translate (cellSize, 0, 0);
					pos = (Vector2)transform.position;
					MapGenerator.me.CheckPlayer ();
					sprite.transform.eulerAngles = new Vector3 (0, 0, -90);
					Master.me.DiscardMovementCard ();
					energy--;
				}
			}

		}

		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) {

			if (Master.me.CheckMovementCard () && energy > 0) {
				
				if (MapGenerator.me.CheckIfOnMap (new Vector2 (pos.x - 1, pos.y))) {
					MapGenerator.me.CheckIfBadTile (new Vector2 (pos.x - 1, pos.y));
					transform.Translate (-cellSize, 0, 0);
					pos = (Vector2)transform.position;
					MapGenerator.me.CheckPlayer ();
					sprite.transform.eulerAngles = new Vector3 (0, 0, 90);
					Master.me.DiscardMovementCard ();
					energy--;
				}
			}
		}
			

		if (Input.GetKeyDown (KeyCode.E)) {

			Master.me.DrawCard ();

		}

		if (Input.GetKeyDown (KeyCode.Space)) {

			Master.me.EndTurn ();

		}

		if (Input.GetKeyDown (KeyCode.Alpha1)) {

			if (Master.me.hand.Count > 0) {
				Master.me.hand [0].GetComponent<CardDisplay> ().CardClicked ();
				Master.me.UpdateLists ();
				Master.me.UpdateCardPositions ();
			}

		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) {

			if (Master.me.hand.Count > 1) {
				Master.me.hand [1].GetComponent<CardDisplay> ().CardClicked ();
				Master.me.UpdateLists ();
				Master.me.UpdateCardPositions ();
			}

		}

		if (Input.GetKeyDown (KeyCode.Alpha3)) {

			if (Master.me.hand.Count > 2) {
				Master.me.hand [2].GetComponent<CardDisplay> ().CardClicked ();
				Master.me.UpdateLists ();
				Master.me.UpdateCardPositions ();
			}
		}

		if (Input.GetKeyDown (KeyCode.Alpha4)) {

			if (Master.me.hand.Count > 3) {
				Master.me.hand [3].GetComponent<CardDisplay> ().CardClicked ();
				Master.me.UpdateLists ();
				Master.me.UpdateCardPositions ();
			}

		}

		if (Input.GetKeyDown (KeyCode.Alpha5)) {

			Debug.Log (Master.me.hand.Count);
			if (Master.me.hand.Count >= 4) {
				Master.me.hand [4].GetComponent<CardDisplay> ().CardClicked ();
				Master.me.UpdateLists ();
				Master.me.UpdateCardPositions ();
			}

		}




	}

	public void MovePlayer(Vector2 pos) {

		transform.position = pos;
		this.pos = new Vector2 ((int)pos.x, (int)pos.y);
		MapGenerator.me.CheckPlayer ();
		sprite.transform.eulerAngles = new Vector3 (0, 0, 0);

	}

	public void MoveForward() {

		transform.Translate (0, cellSize, 0);

	}

	void CheckIfDead() {

		if (health <= 0) {

			ScoreController.me.playerY = (int)this.pos.y;
			ScoreController.me.gold = this.gold;
			UnityEngine.SceneManagement.SceneManager.LoadScene ("gameover");

		}

	}

	void OnTriggerEnter2D(Collider2D coll) {

		//Debug.Log (coll.gameObject.tag);

	}
}
