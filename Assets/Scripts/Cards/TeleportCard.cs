using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCard : Card {

//	if this Card is selected && the selected tile is not null, play card


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Played ();
		
	}
		

	public override void Played() {

		//selected = true
		//listen if selected tile is not null
		//once it is played, deselect the current tile

		//Debug.Log ("trying to play " + gameObject.name);

		if (isSelected && Master.me.selectedTile != null && MapGenerator.me.CheckTile(Master.me.selectedTile.pos)) {
			
			PlayerMovement.me.MovePlayer (Master.me.selectedTile.pos);

			Debug.Log ("played " + gameObject.name);
			//Master.me.DiscardCard (this);
			MapGenerator.me.RevealTiles();
			Master.me.selectedTile = null;

			base.Played ();
			Destroy (this.gameObject);
			Master.me.UpdateLists ();

		} else {
			//play sound effect
			//Debug.Log("need to select a tile first!");
		}
	}
}
