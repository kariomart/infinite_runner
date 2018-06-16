using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreakCard : Card {

	// Use this for initialization
	void Start () {

		cardName = "passage";
		cardDescription = "removes a wall adjacent to you";
		sprite = (Sprite)Master.me.sprites[5];

	}
	
	// Update is called once per frame
	void Update () {

		Played ();

	}

	public override void Played() {


		//Debug.Log ("trying to play " + gameObject.name);

		if (isSelected && Master.me.selectedTile != null) {
			
			TileController tile = Master.me.selectedTile;

			if (tile.gameObject.tag == "Wall") {

//				Debug.Log (Master.me.selectedTile.pos + " " + enemy.pos);
				int dis = (int)(Master.me.selectedTile.pos - PlayerMovement.me.pos).magnitude;
				Debug.Log ("attack dis " + dis);

				if (dis <= 1) {
	
					tile.gameObject.transform.tag = "Untagged";
					tile.sprite.sprite = tile.defaultTile;
					PlayerMovement.me.energy--;
					Master.me.selectedTile = null;
					base.Played ();
					Master.me.DiscardCard (this);

				} else {
					Debug.Log ("not in range"); 
					base.Played ();
				}

			} else {
				Debug.Log ("no enemy on space");
				base.Played ();
			}


		} else {
			//play sound effect
			//Debug.Log("need to select a tile first!");
		}
	}
}
