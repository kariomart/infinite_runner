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


		// 

		// if key = UpArrow  or Key = W
		//       # handle normal keys
//		if key = down: 
//			new_tile = board.below(current_ti
//		else if key = up: 
//			new_tile = board.above(current_ti
//		    player.move(new_tile)
//			unity.display_update(...)
//
//

		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) {

			if (Master.me.CheckMovementCard ()) {
				transform.Translate (0, cellSize, 0);
				pos = (Vector2)transform.position;
				MapGenerator.me.CheckPlayer ();
			}


		}

		if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) {

			if (Master.me.CheckMovementCard ()) {
				transform.Translate (0, -cellSize, 1);
				pos = (Vector2)transform.position;
				MapGenerator.me.CheckPlayer ();
				//Debug.Log (pos.y % 4);
			}

		}

		if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) {

			if (Master.me.CheckMovementCard ()) {
				transform.Translate (cellSize, 0, 0);
				pos = (Vector2)transform.position;
				MapGenerator.me.CheckPlayer ();
			}

		}

		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) {

			if (Master.me.CheckMovementCard ()) {
				transform.Translate (-cellSize, 0, 0);
				pos = (Vector2)transform.position;
				MapGenerator.me.CheckPlayer ();
			}

		}
			

		if (Input.GetKeyDown (KeyCode.E)) {

			Master.me.DrawCard ();

		}
			

		if (Input.GetKeyDown(KeyCode.W) && Master.me.hand.Count > 0) {

	
		}
			


	
	}

	public void MoveForward() {

		transform.Translate (0, cellSize, 0);

	}
}
