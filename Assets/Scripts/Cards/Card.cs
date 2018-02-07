using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

	public bool isSelected;
	public string cardName; 
	public int energy = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Selected() {
		
		Master.me.DeselectCards ();
		isSelected = true;
		Debug.Log (gameObject.name + "was selected");
		//Master.me.selectedTile = null;
	}

	public virtual void Played() {

		isSelected = false;

	}
		
}
