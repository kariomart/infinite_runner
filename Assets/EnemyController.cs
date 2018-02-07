using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveTowardsPlayer() {

		Vector2 dir = PlayerMovement.me.pos - (Vector2)transform.position;

		if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y)) {
			if (dir.x < 0)
				Move (-1, 0);
			if (dir.x > 0)
				Move (1, 0);
		}

		else if (Mathf.Abs(dir.x) < Mathf.Abs(dir.y)) {
			if (dir.y < 0)
				Move (0, -1);
			if (dir.y > 0)
				Move (0, 1);
		}

		else if (Mathf.Abs(dir.x) == Mathf.Abs(dir.y)) {
			if (Random.value > .5f) {
				if (dir.y < 0)
					Move (0, -1);
				if (dir.y > 0)
					Move (0, 1);
			} else {
				if (dir.x < 0)
					Move (-1, 0);
				if (dir.x > 0)
					Move (1, 0);
			}


		}


			
	}

	public void Move(int x, int y) {

		transform.position = new Vector2 (transform.position.x + x, transform.position.y + y);

	}

}
