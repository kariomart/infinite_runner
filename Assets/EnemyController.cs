using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public Vector2 pos;
	public int health = 1;

	// Use this for initialization
	void Start () {

		pos = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (health <= 0) {
			Master.me.enemies.Remove (this);
			Destroy (this.gameObject);
		}
		
	}

	public void MoveTowardsPlayer() {

		Vector2 dir = PlayerMovement.me.pos - (Vector2)transform.position;
		if ((Mathf.Abs (dir.x) == 1 && Mathf.Abs (dir.y) == 0) || (Mathf.Abs (dir.y) == 1 && Mathf.Abs (dir.x) == 0)) {
			Debug.Log ("enemy attacked!");
			PlayerMovement.me.health--;

		}

		float rand = Random.value;

		if (rand > 0.4f) {
		//			Debug.Log (dir);
			if ((Mathf.Abs (dir.x) == 1 && Mathf.Abs (dir.y) == 0) || (Mathf.Abs (dir.y) == 1 && Mathf.Abs (dir.x) == 0)) {
				
			}
			else if (Mathf.Abs (dir.x) > Mathf.Abs (dir.y)) {
				if (dir.x < 0)
					Move (-1, 0);
				if (dir.x > 0)
					Move (1, 0);
			} else if (Mathf.Abs (dir.x) < Mathf.Abs (dir.y)) {
				if (dir.y < 0)
					Move (0, -1);
				if (dir.y > 0)
					Move (0, 1);
			} else if (Mathf.Abs (dir.x) == Mathf.Abs (dir.y)) {
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

		UpdatePos ();
			
	}

	public void Move(int x, int y) {

		if(MapGenerator.me.CheckTile(new Vector2 (transform.position.x + x, transform.position.y + y))) {
			transform.position = new Vector2 (transform.position.x + x, transform.position.y + y);
		}

	}

	public void UpdatePos() {

		pos = new Vector2 ((int)transform.position.x, (int)transform.position.y);

	}

}
