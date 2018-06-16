using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCard : Card {

//	if this Card is selected && the selected tile is not null, play card


	// Use this for initialization
	void Start () {

		cardName = "eye of ra";
		cardDescription = "grants an area of vision on selected tile";
		sprite = (Sprite)Master.me.sprites[4];
 
//		highlightTiles = new Vector2[]{ new Vector2(PlayerMovement.me.pos.x + 1, PlayerMovement.me.pos.y), 
//							new Vector2(PlayerMovement.me.pos.x - 1, PlayerMovement.me.pos.y), 
//							new Vector2(PlayerMovement.me.pos.x, PlayerMovement.me.pos.y + 1), 
//							new Vector2(PlayerMovement.me.pos.x, PlayerMovement.me.pos.y - 1)};
		
	}
	
	// Update is called once per frame
	void Update () {


		Played ();
		//UpdateHighlightPositions ();
		
	}
		

	public override void Played() {

		//selected = true
		//listen if selected tile is not null
		//once it is played, deselect the current tile

		//Debug.Log ("trying to play " + gameObject.name);

		if (isSelected && Master.me.selectedTile != null) {
			
			MapGenerator.me.RevealTiles (Master.me.selectedTile.pos);

			Debug.Log ("played " + gameObject.name);

			Master.me.DiscardCard (this);
			Master.me.selectedTile = null;

			base.Played ();

		} else {
			//play sound effect
			//Debug.Log("need to select a tile first!");
		}
	}

	public void UpdateHighlightPositions() {

		highlightTiles = new Vector2[]{ new Vector2(PlayerMovement.me.pos.x + 1, PlayerMovement.me.pos.y), 
			new Vector2(PlayerMovement.me.pos.x - 1, PlayerMovement.me.pos.y), 
			new Vector2(PlayerMovement.me.pos.x, PlayerMovement.me.pos.y + 1), 
			new Vector2(PlayerMovement.me.pos.x, PlayerMovement.me.pos.y - 1)};


	}
}
