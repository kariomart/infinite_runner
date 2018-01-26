using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float cellSize;
	public float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		DealWithInput ();
		
	}

	void DealWithInput() {


		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) {

			if (Master.me.CheckMovementCard ()) {
				transform.Translate (0, cellSize, 0);
			}


		}

		if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) {

			if (Master.me.CheckMovementCard ()) {
				transform.Translate (0, -cellSize, 0);
			}

		}

		if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) {

			if (Master.me.CheckMovementCard ()) {
				transform.Translate (cellSize, 0, 0);
			}

		}

		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) {

			if (Master.me.CheckMovementCard ()) {
				transform.Translate (-cellSize, 0, 0);
			}

		}
			

		if (Input.GetKeyDown (KeyCode.E)) {

			Master.me.DrawCard ();

		}

		if (Input.anyKeyDown) {

			Master.me.RevealSpaces ();

		}
	}

	public void MoveForward() {

		transform.Translate (0, cellSize, 0);

	}
}
