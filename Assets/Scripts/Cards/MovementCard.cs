using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCard : Card {


	// Use this for initialization
	void Start () {

		cardName = "river";
		cardDescription = "move to any adjacent tile";
		
	}
	
	// Update is called once per frame
	void Update () {

		Played ();
		
	}
		

	public override void Played() {


		if (isSelected && Master.me.selectedTile != null) {

			TileController tile = MapGenerator.me.GetTile (Master.me.selectedTile.pos);

			if (tile != null) {

				//				Debug.Log (Master.me.selectedTile.pos + " " + enemy.pos);
				int dis = (int)(tile.pos - PlayerMovement.me.pos).magnitude;
				Vector2 dir = tile.pos - PlayerMovement.me.pos;

				Debug.Log ("move dis " + dis);

				if (dis <= 1 && !(dir.x == 1 && dir.y == 1)) {

					PlayerMovement.me.MovePlayer (tile.pos);
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
