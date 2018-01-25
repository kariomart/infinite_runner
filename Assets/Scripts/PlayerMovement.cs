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

		DealWithMovement ();
		
	}

	void DealWithMovement() {

		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) {

			transform.Translate (0, cellSize, 0);

		}

		if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) {

			transform.Translate (0, -cellSize, 0);

		}

		if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) {

			transform.Translate (cellSize, 0, 0);

		}

		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) {

			transform.Translate (-cellSize, 0, 0);

		}
	}

	public void MoveForward() {

		transform.Translate (0, cellSize, 0);

	}
}
