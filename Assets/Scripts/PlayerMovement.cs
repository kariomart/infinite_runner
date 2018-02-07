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



	// Use this for initialization
	void Start () {

		if (me == null) {
			me = this;
		} else {
			Destroy (this);
		}



	}
	
	// Update is called once per frame
	void Update () {

		DealWithInput ();
			
	}

	void DealWithInput() {


		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) {

			if (Master.me.CheckMovementCard () && energy > 0) {

				if (MapGenerator.me.CheckTile (new Vector2 (pos.x, pos.y + 1))) {
					transform.Translate (0, cellSize, 0);
					pos = (Vector2)transform.position;
					MapGenerator.me.CheckPlayer ();
					Master.me.DiscardMovementCard ();
					energy--;
				}
			}


		}

		if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) {

			if (Master.me.CheckMovementCard () && energy > 0) {
				
				if (MapGenerator.me.CheckTile (new Vector2 (pos.x, pos.y - 1))) {
					transform.Translate (0, -cellSize, 0);
					pos = (Vector2)transform.position;
					MapGenerator.me.CheckPlayer ();
					Master.me.DiscardMovementCard ();
					energy--;
				}
			}

		}

		if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) {

			if (Master.me.CheckMovementCard () && energy > 0) {
				
				if (MapGenerator.me.CheckTile (new Vector2 (pos.x + 1, pos.y))) {
					transform.Translate (cellSize, 0, 0);
					pos = (Vector2)transform.position;
					MapGenerator.me.CheckPlayer ();
					Master.me.DiscardMovementCard ();
					energy--;
				}
			}

		}

		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) {

			if (Master.me.CheckMovementCard () && energy > 0) {
				
				if (MapGenerator.me.CheckTile (new Vector2 (pos.x - 1, pos.y))) {
					transform.Translate (-cellSize, 0, 0);
					pos = (Vector2)transform.position;
					MapGenerator.me.CheckPlayer ();
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




	
	}

	public void MoveForward() {

		transform.Translate (0, cellSize, 0);

	}
}
