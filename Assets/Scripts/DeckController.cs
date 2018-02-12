using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnMouseDown() {

		Debug.Log ("deck clicked!");

		//Master.me.DrawCard ();
		//Master.me.GetDeckInfo ();
			
	}

	void OnMouseEnter() {

		//Debug.Log ("mousing over deck");
		Master.me.DisplayDeckInfo ();

	}

	void OnMouseExit() {

		//Master.me.ClearDeckInfo ();

	}
		

}
