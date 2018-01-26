using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {

	public SpriteRenderer cover;
	public Vector2 pos;


	// Use this for initialization
	void Start () {

		pos = (Vector2) (transform.position);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual void TileEntered() {

	}



	void OnTriggerEnter2D(Collider2D coll) {

		Debug.Log ("collided");
		if (coll.gameObject.tag == "Vision") {

			cover.enabled = false;

		}

	}
}
