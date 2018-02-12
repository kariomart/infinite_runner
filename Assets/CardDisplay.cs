using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplay : MonoBehaviour {

	Card card;
	float hoverOffset = .5f;
	float hoverSpeed = .1f;
	float floatOffset = 2.5f;
	float floatSpeed = .1f;
	Vector3 floatStartPos;
	float floatEndPos;

	Vector3 startPos;
	float endPos;
	public GameObject selectedFX;

	// Use this for initialization
	void Start () {

		card = GetComponent<Card> ();
		
	}
	
	// Update is called once per frame
	void Update () {


		//Debug.Log (transform.parent);
		//Debug.Log (Master.me.handParent);
		//if (transform.parent == Master.me.handParent.transform) {

			//int index = Master.me.hand.IndexOf (this.gameObject);
			//Vector3 pos = Master.me.handStart.transform.position;
			//transform.position = new Vector3(pos.x + 
		if (card.isSelected && selectedFX != null && !selectedFX.activeInHierarchy) {
			Debug.Log ("hovering");
			floatStartPos = transform.position;
			floatEndPos = transform.position.y + floatOffset;
		}

		if (card.isSelected && selectedFX != null) {

			selectedFX.SetActive (true);
			if (transform.position.y <= floatEndPos) {
				transform.position = new Vector3 (transform.position.x, transform.position.y + floatSpeed, transform.position.z);
			}

		}
	


		if (!card.isSelected && selectedFX != null) {
			selectedFX.SetActive (false);

		}

//		else if (!card.isSelected && selectedFX != null && selectedFX.activeInHierarchy) {
//			//Debug.Log ("not particling");
//			selectedFX.SetActive (false);
//			transform.position = floatStartPos;
//			Debug.Log ("how is this possible");
//		}
				

		//}
		
	}

	public void CardClicked() {

		Debug.Log ("card clicked");
		if (PlayerMovement.me.energy > 0) {
			//Master.me.UpdateCardPositions ();
			card.Selected ();
			//card.Played ();
		}

	



	}

	void OnMouseDown() {

		CardClicked ();


	}
		

	void OnMouseEnter() {

		if (!card.isSelected) {
			startPos = transform.position;
			endPos = transform.position.y + hoverOffset;
		}

	}

	void OnMouseOver() {
//		Debug.Log ("hovering, endpos is: " + endPos);

		if (transform.position.y <= endPos && !card.isSelected) {

			transform.position = new Vector3 (transform.position.x, transform.position.y + hoverSpeed, transform.position.z);

		}

	}

	void OnMouseExit() {

		if (!card.isSelected) {
			transform.position = startPos;
		}

	}

	public void UpdatePosition(int index) {

		Vector3 pos = Master.me.handStart.transform.position;
		float offset = Master.me.handOffset;
		transform.position = new Vector3 (pos.x + (offset * index), pos.y, pos.z + (-.1f * index));


	}




}
