using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplay : MonoBehaviour {

	Card card;
	float hoverOffset = .5f;
	float hoverSpeed = .1f;
	Vector3 startPos;
	float endPos;

	// Use this for initialization
	void Start () {

		card = GetComponent<Card> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.parent == Master.me.handParent) {

			//int index = Master.me.hand.IndexOf (this.gameObject);
			Vector3 pos = Master.me.handStart.transform.position;
			//transform.position = new Vector3(pos.x + 

		}
		
	}

	public void CardClicked() {

		Debug.Log ("card clicked");
		if (PlayerMovement.me.energy > 0) {
			card.Selected ();
			card.Played ();
		}



	}

	void OnMouseDown() {

		CardClicked ();


	}
		

	void OnMouseEnter() {

		startPos = transform.position;
		endPos = transform.position.y + hoverOffset;

	}

	void OnMouseOver() {
//		Debug.Log ("hovering, endpos is: " + endPos);

		if (transform.position.y <= endPos) {

			transform.position = new Vector3 (transform.position.x, transform.position.y + hoverSpeed, transform.position.z);

		}

	}

	void OnMouseExit() {

		transform.position = startPos;


	}

	public void UpdatePosition(int index) {

		Vector3 pos = Master.me.handStart.transform.position;
		float offset = Master.me.handOffset;
		transform.position = new Vector3 (pos.x + (offset * index), pos.y, pos.z + (-.1f * index));


	}


}
