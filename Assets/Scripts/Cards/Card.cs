using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

	public bool isSelected;
	public string cardName; 
	public string cardDescription;
	public int energy = 1;
	public Vector2[] highlightTiles;
	public Sprite sprite;


	// // Use this for initialization
	void Start () {

		
	}
	
	// // Update is called once per frame
	// void Update () {



	// }

	// public virtual void Selected() {
		
	// 	Master.me.DeselectCards ();
	// 	Master.me.UpdateCardPositions ();
	// 	isSelected = true;
	// 	Master.me.selectedCard = this;
	// 	Debug.Log (gameObject.name + "was selected");
	// 	//MapGenerator.me.HighlightTiles (highlightTiles);
	// 	Master.me.selectedTile = null;
	// }

	public virtual void Played() {

		isSelected = false;
		Master.me.selectedCard = null;

	}
		
}
