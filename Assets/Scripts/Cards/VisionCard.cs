using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCard : Card {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		

	public override void Played() {

		if (Master.me.selectedTile != null) {
			MapGenerator.me.RevealTiles (Master.me.selectedTile.pos);
			Master.me.selectedTile = null;
			Master.me.DiscardCard (this);
		} else {
			//play sound effect
			Debug.Log("need to select a tile first!");
		}
	}
}
